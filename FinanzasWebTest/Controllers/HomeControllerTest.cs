using FinanzasWeb.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace FinanzasWebTest.Controllers;

public class HomeControllerTest
{
    [Test]
    public void IndexCase01()
    {
        var controller = new HomeController();
        var view = controller.Index() as ViewResult;
        
        Assert.IsNotNull(view); 
        
    }
    
    [Test]
    public void PrivacyCase01()
    {
        var controller = new HomeController();
        var view = controller.Privacy() as ViewResult;
        Assert.IsNotNull(view); 
        Assert.IsNull(view.Model);
    }
}