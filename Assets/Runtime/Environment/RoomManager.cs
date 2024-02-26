using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;
using UnityEngine.SceneManagement;

namespace ScringloGames.ColorClash.Runtime
{
    public class RoomManager : MonoBehaviour
    {
        [SerializeField]
        private RoomListScriptableObject roomContainer;
        public static int roomIndex = 0;
        
        public void NextRoom()
        {
            roomIndex++;
            SceneManager.LoadScene(roomContainer.roomList[roomIndex]);
        }
    }
}
