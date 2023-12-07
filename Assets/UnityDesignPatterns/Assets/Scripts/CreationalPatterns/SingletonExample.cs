using UnityEngine;

public class SingletonExample : MonoBehaviour
{
    // Static instance of SingletonExample which allows it to be accessed by any other script.
    public static SingletonExample instance = null;

    // Awake is always called before any Start functions
    void Awake()
    {
        // Check if instance already exists
        if (instance == null)
        {
            // If not, set instance to this
            instance = this;
        }
        // If instance already exists and it's not this:
        else if (instance != this)
        {
            // Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a SingletonExample.
            Destroy(gameObject);
        }

        // Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }

    // Other functions can go here
}