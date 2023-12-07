using UnityEngine;

public class FacadeExample : MonoBehaviour
{
    // Subsystem classes
    class SubsystemA
    {
        public string OperationA() => "Subsystem A, Method A\n";
    }

    class SubsystemB
    {
        public string OperationB() => "Subsystem B, Method B\n";
    }

    class SubsystemC
    {
        public string OperationC() => "Subsystem C, Method C\n";
    }

    // Facade class
    class Facade
    {
        private SubsystemA _subsystemA;
        private SubsystemB _subsystemB;
        private SubsystemC _subsystemC;

        public Facade()
        {
            _subsystemA = new SubsystemA();
            _subsystemB = new SubsystemB();
            _subsystemC = new SubsystemC();
        }

        public string Operation()
        {
            string result = "Facade initializes subsystems:\n";
            result += _subsystemA.OperationA();
            result += _subsystemB.OperationB();
            result += _subsystemC.OperationC();
            return result;
        }
    }

    void Start()
    {
        Facade facade = new Facade();
        Debug.Log(facade.Operation());
    }
}