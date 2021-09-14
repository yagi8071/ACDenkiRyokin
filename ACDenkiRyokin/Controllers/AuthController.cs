using ACDenkiRyokin.Models;
using System.Web.Mvc;
using System.Web.Security;

namespace ACDenkiRyokin.Controllers
{
    public class AuthController : Controller
    {
        /// <summary>
        /// ログイン 表示
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// ログイン処理
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(AuthModel model)
        {
            // サンプルの為、ハードコーディング
            if (model.Id == "test" && model.Password == "test")
            {
                // ユーザー認証 失敗
                FormsAuthentication.SetAuthCookie(model.Id, true);
                return RedirectToAction("Index", "Lendlist");
            }
            else
            {
                // ユーザー認証 失敗
                this.ModelState.AddModelError(string.Empty, "指定されたユーザー名またはパスワードが正しくありません。");
                return this.View(model);
            }
        }

        /// <summary>
        /// ログアウト処理
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Auth", "Index");
        }
    }
}