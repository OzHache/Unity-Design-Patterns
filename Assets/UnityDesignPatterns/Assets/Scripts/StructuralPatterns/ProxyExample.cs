using UnityEngine;

public interface IImage
{
    void Display();
}

public class RealImage : IImage
{
    private string _fileName;

    public RealImage(string fileName)
    {
        _fileName = fileName;
        LoadFromDisk();
    }

    private void LoadFromDisk()
    {
        Debug.Log("Loading " + _fileName);
    }

    public void Display()
    {
        Debug.Log("Displaying " + _fileName);
    }
}

public class ProxyImage : IImage
{
    private RealImage _realImage;
    private string _fileName;

    public ProxyImage(string fileName)
    {
        _fileName = fileName;
    }

    public void Display()
    {
        if (_realImage == null)
        {
            _realImage = new RealImage(_fileName);
        }
        _realImage.Display();
    }
}

public class ProxyExample : MonoBehaviour
{
    void Start()
    {
        IImage image1 = new ProxyImage("TestImage1");
        IImage image2 = new ProxyImage("TestImage2");

        // Image will be loaded from disk
        image1.Display();
        // Image will not be loaded from disk
        image1.Display();

        // Image will be loaded from disk
        image2.Display();
        // Image will not be loaded from disk
        image2.Display();
    }
}