using Microsoft.AspNetCore.Mvc;
using NWebsec.AspNetCore.Mvc.Csp;

namespace MvcAttributeWebsite.Controllers
{
    public class FeaturePolicyConfigController : Controller
    {
        //
        // GET: /FeaturePolicyConfig/

        public ActionResult Index()
        {
            return this.View("Index");
        }

        [CspScriptSrc(CustomSources = "attributescripthost")]
        public ActionResult AddSource()
        {
            return this.View("Index");
        }

        [CspScriptSrc(CustomSources = "attributescripthost", InheritCustomSources = false)]
        public ActionResult OverrideSource()
        {
            return this.View("Index");
        }

        [Csp(Enabled = false)]
        public ActionResult DisableCsp()
        {
            return this.View("Index");
        }

        [CspScriptSrc(UnsafeInline = true, UnsafeEval = true)]
        public ActionResult ScriptSrcAllowInlineUnsafeEval()
        {
            return this.View("Index");
        }
    }
}