// See https://aka.ms/new-console-template for more information

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Memory;

Console.WriteLine("Hello, World!");

Configuration.Default.MemoryAllocator = MemoryAllocator.Create(new MemoryAllocatorOptions
{
    MaximumPoolSizeMegabytes = 1024
});

await Task.WhenAll(Enumerable.Range(0, 5).Select(_ => SaveLoadImage()));

return;

static Task SaveLoadImage()
{
    return Task.Run(() =>
    {
        using var ms = new MemoryStream(File.ReadAllBytes("funnyanim.gif"));

        var image = Image.Load(ms);
        image.Metadata.ExifProfile = null;
        image.Metadata.IccProfile = null;
        image.Metadata.IptcProfile = null;
        image.Metadata.XmpProfile = null;

        var id = Guid.NewGuid();
        image.Save($"result-{id}.gif");
    });
}