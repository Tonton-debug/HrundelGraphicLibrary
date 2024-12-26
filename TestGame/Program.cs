using HGL.Render.Window;
using HGL.Scenes;
using TestGame;

internal class Program
{
    private static void Main(string[] args)
    {
        SceneManager.Instance.AddScene(new MainScene());
        using(HGLWindow window=new HGLWindow())
        {
            window.Run();
        }
    }
}