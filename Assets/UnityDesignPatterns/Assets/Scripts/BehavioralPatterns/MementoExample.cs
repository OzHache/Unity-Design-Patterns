using UnityEngine;

public class MementoExample : MonoBehaviour
{
    public class Memento
    {
        private string state;

        public Memento(string stateToSave)
        {
            state = stateToSave;
        }

        public string GetSavedState()
        {
            return state;
        }
    }

    public class Originator
    {
        private string state;

        public void Set(string state)
        {
            Debug.Log("Originator: Setting state to " + state);
            this.state = state;
        }

        public Memento SaveToMemento()
        {
            Debug.Log("Originator: Saving to Memento.");
            return new Memento(state);
        }

        public void RestoreFromMemento(Memento memento)
        {
            state = memento.GetSavedState();
            Debug.Log("Originator: State after restoring from Memento: " + state);
        }
    }

    public class Caretaker
    {
        private Memento memento;

        public void SaveState(Originator originator)
        {
            memento = originator.SaveToMemento();
        }

        public void RestoreState(Originator originator)
        {
            originator.RestoreFromMemento(memento);
        }
    }

    void Start()
    {
        Originator originator = new Originator();
        Caretaker caretaker = new Caretaker();

        originator.Set("State1");
        originator.Set("State2");
        caretaker.SaveState(originator);
        originator.Set("State3");
        caretaker.RestoreState(originator);
    }
}