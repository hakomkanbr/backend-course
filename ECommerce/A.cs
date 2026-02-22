namespace ECommerce;

public class A
{
    private readonly RequestDelegate _next;

    public A(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        Console.WriteLine(DateTime.Now);
        await _next.Invoke(context);
        Console.WriteLine(DateTime.Now);
        // After
    }
}

public class B
{
    private readonly RequestDelegate _next;

    public B(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        await _next.Invoke(context);

        //
    }
}

public class C
{
    private readonly RequestDelegate _next;

    public C(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        await _next.Invoke(context);


    }
}
