using UnityEngine;

namespace Circuit
{
    public class CircuitApplicationManager : MonoBehaviour
    {
        private SceneHandler _sceneHandler;

        [field : SerializeField] public bool ApplicationStart {  get; private set; }

        private void Awake()
        {
            _sceneHandler = new SceneHandler();
        }

        // Start is called before the first frame update
        void Start()
        {
            if (!ApplicationStart)
            {
                

                _sceneHandler.ChangeScene(SceneHandler.Scene.Login);

                Debug.Log($"{nameof(CircuitApplicationManager)} \t {nameof(Start)} \t Application Start {ApplicationStart}");
                ApplicationStart = true;
            }
            


        }

        // Update is called once per frame
        void Update()
        {

        }


        private void OnDestroy()
        {
            ApplicationStart = false;
            Debug.Log($"{nameof(CircuitApplicationManager)} \t {nameof(OnDestroy)} \t Application Start {ApplicationStart}");
        }


    }
}

