// See https://aka.ms/new-console-template for more information

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Memory;

Console.WriteLine("Hello, World!");

Configuration.Default.MemoryAllocator = MemoryAllocator.Create(new MemoryAllocatorOptions
{
    AllocationLimitMegabytes = 192
});

using var ms = new MemoryStream(File.ReadAllBytes("40-frames.gif"));
using var image = Image.Load(ms);
image.Metadata.ExifProfile = null;
image.Metadata.IccProfile = null;
image.Metadata.IptcProfile = null;
image.Metadata.XmpProfile = null;

var id = Guid.NewGuid();
image.Save($"result-{id}.gif");