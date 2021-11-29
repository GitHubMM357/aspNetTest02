using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuickMaster.Models;
using System.Linq;
using System.Threading.Tasks;

namespace QuickMaster.ViewComponents
{
    // a. ビューコンポーネントを定義
    public class ListViewComponent : ViewComponent
    {
        private readonly MyContext _context;
        // コンテキストクラスを有効化
        public ListViewComponent(MyContext context)
        {
            this._context = context;
        }
        // b. ビューコンポーネントの実処理
        public async Task<IViewComponentResult> InvokeAsync(int price)
        {
            // c. price円以上の書籍を取得
            return View(await _context.Book
                .Where(b => b.Price >= price).ToListAsync());
        }
    }
}