using UnityEngine.SceneManagement;

public static class MySceneManager
{
    public static void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public static void LoadSameScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}