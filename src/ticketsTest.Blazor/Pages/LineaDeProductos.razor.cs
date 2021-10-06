using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazorise;
using Blazorise.DataGrid;
using Volo.Abp.BlazoriseUI.Components;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Components.Web.Theming.PageToolbars;
using ticketsTest.LineaDeProductos;
using ticketsTest.Permissions;
using ticketsTest.Shared;

namespace ticketsTest.Blazor.Pages
{
    public partial class LineaDeProductos
    {
        protected List<Volo.Abp.BlazoriseUI.BreadcrumbItem> BreadcrumbItems = new List<Volo.Abp.BlazoriseUI.BreadcrumbItem>();
        protected PageToolbar Toolbar {get;} = new PageToolbar();
        private IReadOnlyList<LineaDeProductoDto> LineaDeProductoList { get; set; }
        private int PageSize { get; } = LimitedResultRequestDto.DefaultMaxResultCount;
        private int CurrentPage { get; set; } = 1;
        private string CurrentSorting { get; set; }
        private int TotalCount { get; set; }
        private bool CanCreateLineaDeProducto { get; set; }
        private bool CanEditLineaDeProducto { get; set; }
        private bool CanDeleteLineaDeProducto { get; set; }
        private LineaDeProductoCreateDto NewLineaDeProducto { get; set; }
        private Validations NewLineaDeProductoValidations { get; set; }
        private LineaDeProductoUpdateDto EditingLineaDeProducto { get; set; }
        private Validations EditingLineaDeProductoValidations { get; set; }
        private Guid EditingLineaDeProductoId { get; set; }
        private Modal CreateLineaDeProductoModal { get; set; }
        private Modal EditLineaDeProductoModal { get; set; }
        private GetLineaDeProductosInput Filter { get; set; }
        private DataGridEntityActionsColumn<LineaDeProductoDto> EntityActionsColumn { get; set; }
        
        public LineaDeProductos()
        {
            NewLineaDeProducto = new LineaDeProductoCreateDto();
            EditingLineaDeProducto = new LineaDeProductoUpdateDto();
            Filter = new GetLineaDeProductosInput
            {
                MaxResultCount = PageSize,
                SkipCount = (CurrentPage - 1) * PageSize,
                Sorting = CurrentSorting
            };
        }

        protected override async Task OnInitializedAsync()
        {
            await SetToolbarItemsAsync();
            await SetBreadcrumbItemsAsync();
            await SetPermissionsAsync();
        }

        protected virtual ValueTask SetBreadcrumbItemsAsync()
        {
            BreadcrumbItems.Add(new Volo.Abp.BlazoriseUI.BreadcrumbItem(L["Menu:LineaDeProductos"]));
            return ValueTask.CompletedTask;
        }

        protected virtual ValueTask SetToolbarItemsAsync()
        {
            Toolbar.AddButton(L["NewLineaDeProducto"], () =>
            {
                OpenCreateLineaDeProductoModal();
                return Task.CompletedTask;
            }, IconName.Add, requiredPolicyName: ticketsTestPermissions.LineaDeProductos.Create);

            return ValueTask.CompletedTask;
        }

        private async Task SetPermissionsAsync()
        {
            CanCreateLineaDeProducto = await AuthorizationService
                .IsGrantedAsync(ticketsTestPermissions.LineaDeProductos.Create);
            CanEditLineaDeProducto = await AuthorizationService
                            .IsGrantedAsync(ticketsTestPermissions.LineaDeProductos.Edit);
            CanDeleteLineaDeProducto = await AuthorizationService
                            .IsGrantedAsync(ticketsTestPermissions.LineaDeProductos.Delete);
        }

        private async Task GetLineaDeProductosAsync()
        {
            Filter.MaxResultCount = PageSize;
            Filter.SkipCount = (CurrentPage - 1) * PageSize;
            Filter.Sorting = CurrentSorting;

            var result = await LineaDeProductosAppService.GetListAsync(Filter);
            LineaDeProductoList = result.Items;
            TotalCount = (int)result.TotalCount;
        }

        protected virtual async Task SearchAsync()
        {
            CurrentPage = 1;
            await GetLineaDeProductosAsync();
            await InvokeAsync(StateHasChanged);
        }

        private async Task OnDataGridReadAsync(DataGridReadDataEventArgs<LineaDeProductoDto> e)
        {
            CurrentSorting = e.Columns
                .Where(c => c.Direction != SortDirection.None)
                .Select(c => c.Field + (c.Direction == SortDirection.Descending ? " DESC" : ""))
                .JoinAsString(",");
            CurrentPage = e.Page;
            await GetLineaDeProductosAsync();
            await InvokeAsync(StateHasChanged);
        }

        private void OpenCreateLineaDeProductoModal()
        {
            NewLineaDeProducto = new LineaDeProductoCreateDto{
                
                
            };
            NewLineaDeProductoValidations.ClearAll();
            CreateLineaDeProductoModal.Show();
        }

        private void CloseCreateLineaDeProductoModal()
        {
            CreateLineaDeProductoModal.Hide();
        }

        private void OpenEditLineaDeProductoModal(LineaDeProductoDto input)
        {
            EditingLineaDeProductoId = input.Id;
            EditingLineaDeProducto = ObjectMapper.Map<LineaDeProductoDto, LineaDeProductoUpdateDto>(input);
            EditingLineaDeProductoValidations.ClearAll();
            EditLineaDeProductoModal.Show();
        }

        private async Task DeleteLineaDeProductoAsync(LineaDeProductoDto input)
        {
            await LineaDeProductosAppService.DeleteAsync(input.Id);
            await GetLineaDeProductosAsync();
        }

        private async Task CreateLineaDeProductoAsync()
        {
            await LineaDeProductosAppService.CreateAsync(NewLineaDeProducto);
            await GetLineaDeProductosAsync();
            CreateLineaDeProductoModal.Hide();
        }

        private void CloseEditLineaDeProductoModal()
        {
            EditLineaDeProductoModal.Hide();
        }

        private async Task UpdateLineaDeProductoAsync()
        {
            await LineaDeProductosAppService.UpdateAsync(EditingLineaDeProductoId, EditingLineaDeProducto);
            await GetLineaDeProductosAsync();
            EditLineaDeProductoModal.Hide();
        }

        public List<ContactPhoneCreateDto> SomeData { get; set; } = new() { new() { Phone = "123", Type = "Work" } };
        private ContactPhoneCreateDto SelectedItemPhone;
        private void OnNewItemDefaultSetterPhone(ContactPhoneCreateDto item) {
            item.Type = "Test";
        }
    }

    public class ContactPhoneCreateDto {
        public string Type { get; set; }
        public string Phone { get; set; }
    }
}
