using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Circuit
{
    /// <summary>
    /// Scene handler
    /// </summary>
    public class SceneHandler 
    {

       /* public delegate void SceneDelegate(Scene scene);
        public static SceneDelegate OnSceneChanged;*/

        public enum Scene : byte
        {
            Main = 1,
            Login,
            Game
        }

        [field: SerializeField] public Scene scene { get; private set; }

        // Start is called before the first frame update
        void Start()
        {
            //OnSceneChanged += ChangeScene;
        }

        private void OnDestroy()
        {
            //OnSceneChanged -= ChangeScene;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loadSceneName"></param>
        public void ChangeScene(Scene loadSceneName)
        {
            if(loadSceneName == Scene.Login)
            {
                ChangeToLoginScene();
            }
            if(loadSceneName == Scene.Game)
            {
                ChangeToGameScene();
            }
            // AsyncOperation sceneAsyncOperation = SceneManager.LoadSceneAsync(loadSceneName.ToString().Trim(), loadSceneMode);
            this.scene = loadSceneName;
            Debug.Log($"Scene {this.scene} loaded successfully........");
            
        }


        void ChangeToLoginScene()
        {
            SceneManager.LoadSceneAsync(Scene.Login.ToString().Trim(), LoadSceneMode.Additive);
        }

        void ChangeToGameScene()
        {
            SceneManager.LoadSceneAsync(Scene.Game.ToString().Trim(), LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync(Scene.Login.ToString().Trim());
        }




    }
}

