using System;
using BepInEx;
using Cinemachine;
using UnityEngine;
using Utilla;

namespace TysBetterFirstPerson
{
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        private GameObject ShoulderCamera;
        private GameObject plr;
        
        // ToDo: finish the enabled thingy
        private bool enabled;
        public void Update()
        {
            if (plr == null)
            {
                plr = Camera.main.gameObject;
            }
            
            if (ShoulderCamera == null)
            {
                ShoulderCamera = GameObject.Find("Shoulder Camera");
            }
            else
            {
                
                if (ShoulderCamera.GetComponent<Camera>() != null)
                {
                    ShoulderCamera.GetComponent<Camera>().fieldOfView = 110;
                }
                
                ShoulderCamera.GetComponent<CinemachineBrain>().enabled = false;
                if (plr != null)
                {
                    ShoulderCamera.transform.position = Vector3.Lerp(
                        ShoulderCamera.transform.position,
                        plr.transform.position + new Vector3(0, 0.1f, 0f) + plr.transform.forward * 0.2f,
                        Time.deltaTime / 0.005f
                    );
                    ShoulderCamera.transform.rotation = Quaternion.Lerp(
                        ShoulderCamera.transform.rotation,
                        plr.transform.rotation,
                        Time.deltaTime / 0.1f
                    );

                }
            }
        }
    }
}