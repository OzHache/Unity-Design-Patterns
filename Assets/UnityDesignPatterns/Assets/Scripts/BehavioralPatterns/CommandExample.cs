using UnityEngine;

public class CommandExample : MonoBehaviour
{
    // Command interface
    public interface ICommand
    {
        void Execute();
    }

    // Concrete command
    public class RenderCommand : ICommand
    {
        private readonly Renderer _renderer;

        public RenderCommand(Renderer renderer)
        {
            _renderer = renderer;
        }

        public void Execute()
        {
            var randomColor = new Color(Random.value, Random.value, Random.value);
            _renderer.material.color = randomColor;
        }
    }

    // Invoker
    public class Player
    {
        private ICommand _renderCommand;

        public void SetRenderCommand(ICommand renderCommand)
        {
            _renderCommand = renderCommand;
        }

        public void Change()
        {
            _renderCommand?.Execute();
            Debug.Log("Player changed");
        }
    }

    // Client
    private Player _player;
    private Renderer _renderer;

    private void Start()
    {
        _player = new Player();
        _renderer = GetComponent<Renderer>();
        _player.SetRenderCommand(new RenderCommand(_renderer));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _player.Change();
        }
    }
}