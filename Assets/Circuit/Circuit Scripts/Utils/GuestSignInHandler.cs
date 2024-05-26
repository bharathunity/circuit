using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Circuit
{
    public class GuestSignInHandler : MonoBehaviour
    {
        [SerializeField] private Button guestSignIn;

        SceneHandler _sceneHandler;


        private void Awake()
        {
            _sceneHandler = new SceneHandler();
            guestSignIn.onClick.AddListener(GuestSiginIn);
        }

        void GuestSiginIn()
        {
            _sceneHandler.ChangeScene(SceneHandler.Scene.Menu);
        }
    }
}

