using Circuit;
using Google;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;


namespace CircuitAuthentication
{
    public class GoogleSiginInHandler : MonoBehaviour
    {



        [SerializeField] string webClientId = "<your client id here>";
        [SerializeField] string pcClinetId = string.Empty;


        [SerializeField] Button _signInButton;

        

        private GoogleSignInConfiguration configuration;

        private SceneHandler _sceneHandler;

        void Awake()
        {
            /*string clientId = string.Empty;

#if UNITY_ANDROID
            clientId = webClientId;
#endif
#if UNITY_EDITOR_WIN
            clientId = webClientId;
#endif
*/
            _signInButton.onClick.AddListener(GoogleSiginIn);
            _sceneHandler = new SceneHandler();

            configuration = new GoogleSignInConfiguration
            {
                WebClientId = webClientId,
                RequestIdToken = true
            };
        }

        // Start is called before the first frame update
        void Start()
        {

        }


        /// <summary>
        /// 
        /// </summary>
        public void GoogleSiginIn()
        {
            GoogleSignIn.Configuration = configuration;
            GoogleSignIn.Configuration.UseGameSignIn = false;
            GoogleSignIn.Configuration.RequestIdToken = true;
            GoogleSignIn.Configuration.RequestEmail = true;
            GoogleSignIn.Configuration.RequestProfile = true;
            GoogleSignIn.Configuration.RequestAuthCode = true;

            

            Debug.Log("Calling SignIn");

            GoogleSignIn.DefaultInstance.SignIn().ContinueWith(
              OnGoogleAuthenticationFinished, TaskScheduler.Current);
        }

        public void GoogleSignOut()
        {

            GoogleSignIn.DefaultInstance.SignOut();
            Debug.Log("Calling SignOut");
        }

        internal void OnGoogleAuthenticationFinished(Task<GoogleSignInUser> task)
        {
            if (task.IsFaulted)
            {
                using (IEnumerator<System.Exception> enumerator =
                        task.Exception.InnerExceptions.GetEnumerator())
                {
                    if (enumerator.MoveNext())
                    {
                        GoogleSignIn.SignInException error =
                                (GoogleSignIn.SignInException)enumerator.Current;
                        Debug.Log("Got Error: " + error.Status + " " + error.Message);
                    }
                    else
                    {
                        Debug.Log("Got Unexpected Exception?!?" + task.Exception);
                    }
                }
            }
            else if (task.IsCanceled)
            {
                Debug.Log("Canceled");
            }
            else
            {
                Debug.Log("Welcome: " + task.Result.DisplayName + "!");
                Debug.Log("Given Name: " + task.Result.GivenName + "!");
                Debug.Log("Image URL: " + task.Result.ImageUrl + "!");
                Debug.Log("Email: " + task.Result.Email + "!");
                Debug.Log("Id Token: " + task.Result.IdToken + "!");
                Debug.Log("Auth code: " + task.Result.AuthCode + "!");

                // SceneHandler.OnSceneChanged?.Invoke(SceneHandler.Scene.Game);
                
                _sceneHandler.ChangeScene(SceneHandler.Scene.Menu);
            }

            
        }
    }
}

