using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

namespace UnityEngine.Rendering.Universal
{
    public class ModuleUSes : MonoBehaviour
    {
        public string type;
        public string name;
        public GameObject[] turret;
        public AudioClip[] sounds;
        public Light2D[] lights;
        public Spaceship spaceship;
        public Extract Extract;
        public bool extractor;
        bool change = true;
        public GameObject anotherTurret;
        public WEAPON weapon;
        public Jukebox TheJukebox;
public float R;
public float G;
public float B;
        // Start is called before the first frame update
        void Start()
        {
           
        }

        // Update is called once per frame
        void Update()
        {
foreach(Light2D light2D in lights)
            {
                light2D.color = new Color(R, G, B);
            }
            /*if (change)
            {
                StartCoroutine(Disco());
            }*/
        }
        IEnumerator Disco()
        {
            change = false;
            foreach(Light2D light2D in lights)
            {
                light2D.color = new Color(Random.Range(0, 10), Random.Range(0, 10), Random.Range(0, 10));
            }
            yield return new WaitForSeconds(0.5f);
            change = true;
        }
        public void putAModule(Module module)
        {
            switch (module.type)
            {
                case "jukebox":
                    ModuleJukebox(module.name);
                    break;
                case "shield":
                    ModuleShield();
                    break;
                case "turret":
                    ModuleTurret(module);
                    break;
                case "extractor":
                    ModuleExtractor();
                    break;
                case "light":
                    break;
            }
        }
        void ModuleJukebox(string diskName)
        {
            AudioClip TheSongToShare = null;
            Debug.Log(diskName);
            foreach(AudioClip song in sounds)
            {
                if(song.name == diskName)
                {
                    TheSongToShare = song;
                }
            }
            Debug.Log(TheSongToShare.name);
            TheJukebox.addTrack(TheSongToShare);
        }
        void ModuleShield()
        {
            spaceship.shield = true;
        }
        void ModuleTurret(Module module)
        {
            if(module.name == "poser")
            {
                anotherTurret.SetActive(true);
                weapon.EnableTheSecondWeapon = true;
                
            }
            else
            {
                weapon.attack = weapon.attack * 2;
            }
        }
        void ModuleExtractor()
        {
            Extract.CanExtractComet = true;
        }
        void ModuleLight()
        {

        }
    }
}
