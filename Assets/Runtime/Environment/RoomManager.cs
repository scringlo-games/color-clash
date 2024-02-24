using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;
using UnityEngine.SceneManagement;

namespace ScringloGames.ColorClash.Runtime
{
    public class RoomManager : MonoBehaviour
    {
        public static List<string> rooms;
        public static int roomIndex;

        void NextRoom()
        {
            SceneManager.LoadScene(rooms[roomIndex]);
            roomIndex++;
        }
    }
}
