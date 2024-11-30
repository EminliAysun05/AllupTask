using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allup.Application.UI.ViewModels
{
    public class BasketUiViewModel
    {
        public List<BasketViewModel>? BasketItems { get; set; } = new();
        public decimal TotalAmount => BasketItems?.Sum(x => x.Product?.Price * x.Count ?? 0) ?? 0;
        public int TotalCount => BasketItems?.Sum(x => x.Count) ?? 0;
    }
}
