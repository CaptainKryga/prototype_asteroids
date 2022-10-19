using System;
using UnityEngine;

namespace Controller
{
    public class CustomInput : MonoBehaviour
    {
        public Action<Vector2> UpdateWASD_Action;
        public Action<Vector2> UpdateMouseClick_Action;

        private void Update()
        {
            Vector2 wasd = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            UpdateWASD_Action?.Invoke(wasd);

            if (Input.GetKeyDown(KeyCode.Mouse0))
                UpdateMouseClick_Action?.Invoke(Input.mousePosition);
        }
    }
}
