using EventSupportApp.Components;
using EventSupportApp.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext Factory for Blazor Server concurrency safety
builder.Services.AddDbContextFactory<AppDbContext>(options =>
    options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PERTAEVENT;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True", o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Auto-migrate SQL Server database
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
    
    // Auto-create AuditLogs if not exists (raw SQL)
    db.Database.ExecuteSqlRaw(@"
        IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='AuditLogs' and xtype='U')
        BEGIN
            CREATE TABLE AuditLogs (
                IdLog INT IDENTITY(1,1) PRIMARY KEY,
                Waktu DATETIME2 NOT NULL,
                Username NVARCHAR(100),
                Aksi NVARCHAR(200),
                Detail NVARCHAR(MAX)
            );

            INSERT INTO AuditLogs (Waktu, Username, Aksi, Detail) VALUES 
            (DATEADD(day, -2, GETDATE()), 'admin', 'Login', 'Admin masuk ke sistem'),
            (DATEADD(day, -1, GETDATE()), 'helpdesk', 'Tambah Acara', 'Membuat acara Rapat Pleno Dekanat'),
            (DATEADD(hour, -5, GETDATE()), 'admin', 'Assign Teknisi', 'Menugaskan Pak Joko untuk Rapat Pleno Dekanat'),
            (DATEADD(hour, -2, GETDATE()), 'pak_joko', 'Konfirmasi Penugasan', 'Teknisi menandatangani konfirmasi penugasan'),
            (DATEADD(hour, -1, GETDATE()), 'helpdesk', 'Edit Acara', 'Mengedit daftar kebutuhan IT untuk acara Seminar Nasional IT & AI')
        END
    ");
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
app.Run();
