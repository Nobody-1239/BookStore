using BookStore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;

namespace BookStore.ViewComponents
{
    public class ProductGroupComponent: ViewComponent
    {
        private BookStoreContext _bookStoreContext;
        public ProductGroupComponent( BookStoreContext context)
        {
            _bookStoreContext = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("/Views/Component/ViewComponent.cshtml",_bookStoreContext.categories.ToList());
        }
    }
}