// See https://aka.ms/new-console-template for more information

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Memory;

Console.WriteLine("Hello, World!");

Configuration.Default.MemoryAllocator = MemoryAllocator.Create(new MemoryAllocatorOptions
{
    MaximumPoolSizeMegabytes = 1024
});

SaveLoadImage("83");
SaveLoadImage("92");
SaveLoadImage("93");

return;

static void SaveLoadImage(string fileName)
{
    using var input = new MemoryStream(File.ReadAllBytes($"{fileName}.jpg"));

    var image = Image.Load(input);
    image.Metadata.ExifProfile = null;
    image.Metadata.IccProfile = null;
    image.Metadata.IptcProfile = null;
    image.Metadata.XmpProfile = null;

    using var output = new MemoryStream();
    var encoder = new JpegEncoder { Quality = 75 };
    image.Save(output, encoder);
    Console.WriteLine($"Input: {input.Length} vs Output: {output.Length}");
}