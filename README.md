## RUN mode

1. Browse with

![](assets\002.PNG)


Set multiple browsers as default.

![](assets\003.PNG)


## ASP.NET Web Pages 


1. Create New website

Select **ASP.NET Web Site (Razor v3)**

![](assets\001.PNG)




## MVC 

1. Content Result

The following action will return content-type:text/xml

* Controller.cs

```
public ActionResult XmlDemo()
{
    string data = "<Name>JB</Name><Gender>Male</Gender>";
    return Content(data, "text/xml");
}

public ActionResult JsonDemo()
{
    var data = new
    {
        id = "JB",
        gender = "male",
        phone = "0933xxxxxx"
    };

    return Json(data, JsonRequestBehavior.AllowGet);
}
```


2. ASYNC actions in Controller 

![](assets/004.PNG)



3. ActionFilterAttribute

* Action
* Controller
* Global asax

```
protected void Application_Start()
{
    //...
    GlobalFilters.Filters.Add(new LogFilterAttribute());
}
```



4. AJAX Helper


> [Reference](http://www.c-sharpcorner.com/article/Asp-Net-mvc-ajax-helper/)


5. Add default namespaces on view

* In Views/web.config

```
<system.web.webPages.razor>
    <pages pageBaseType="System.Web.Mvc.WebViewPage">
      <namespaces>
        <add namespace="System.Web.Optimization" />
      </namespaces>
    </pages>
  </system.web.webPages.razor>
```


6. Bundle

  * Create `BundleConfig.cs`

  * Register bundles
    
    **Global.asax**

```
protected void Application_Start()
{
    BundleConfig.RegisterBundles(BundleTable.Bundles);
}
```


7. Performance tunning

* Close debug

```
<system.web>
    <compilation debug="false" targetFramework="4.6.1" />
</system.web>
```

* BundleTable.EnableOptimizations

Add `BundleTable.EnableOptimizations=true;` on `BundleConfig.cs`.
```

```




### Exception handling




