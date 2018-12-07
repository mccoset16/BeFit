/* BeFit | fitNessMod
 * Purpose: Count and store calories burned while playing BeatSaber
 * Date: 12/7/18
 * O: Viscoci
 * C: --
 * */
using IllusionPlugin;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

namespace fitNessmod
{
    public class Plugin : IPlugin
    {
        public string Name => "fitNessMod";
        public string Version => "0.1.0";
        bool enabled = true;
        private readonly string[] env = { "DefaultEnvironment", "BigMirrorEnvironment", "TriangleEnvironment", "NiceEnvironment" };
        private int lifeCalories = ModPrefs.GetInt("fitNessMod", "lifeCalories", 0, true);
        private int dailyCalories = ModPrefs.GetInt("fitNessMod", "dailyCalories", 0, true);
        private string rdCals = ModPrefs.GetString("fitNessMod", "date", "dd.MM.yyyy", true);
        public static Vector3 counterPosition = new Vector3(-4.25f, 0.5f, 7f);
        CalorieCounter calCount;
        MenuDisplay display;
        public void OnApplicationStart()
        {
            ModPrefs.SetString("fitNessMod", "version", "v " + Version.ToString());
            ModPrefs.SetInt("fitNessMod", "sessionCalories", 0);
            Console.WriteLine("[fitNessMod | LOG] Current Session Cals set to 0!");
            Console.WriteLine("[fitNessMod | LOG] Daily Calories loaded: " + dailyCalories);
            Console.WriteLine("[fitNessMod | LOG] Life of Mod Calories : " + lifeCalories);
            Console.WriteLine("[fitNessMod | LOG] Current Date: " + DateTime.Now.ToString("dd.MM.yyyy"));
            Console.WriteLine("[fitNessMod | LOG] Last Burn Date: " + rdCals);
            Console.WriteLine("[fitNessMod | LOG] Loaded!");
            SceneManager.activeSceneChanged += SceneManagerOnActiveSceneChanged;
            SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        }

        private void SceneManagerOnActiveSceneChanged(Scene arg0, Scene arg1)
        {
            if (!enabled) return;
            if (arg1.name == "GameCore") {  //Launch calories counter
                Console.WriteLine("[fitNessMod | LOG] Scene Loaded succesfully");
                calCount = null;
                calCount = new GameObject("CalorieCounter").AddComponent<CalorieCounter>();
                Console.WriteLine("[fitNessMod | LOG] calorie counter loaded!");
            }
            
            if (arg1.name == "Menu" /*|| arg1.name == "HealthWarning"*/) //On menu == display. HealthWarning used for layout setup. Will be removed later.
            {
                if (display != null) { return; }
                display = new GameObject("MenuDisplay").AddComponent<MenuDisplay>();
                Console.WriteLine("[fitNessMod | LOG] Menu  calories displayed");
            }
            return;
        }

        private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
        }

        public void OnApplicationQuit()
        {
            SceneManager.activeSceneChanged -= SceneManagerOnActiveSceneChanged;
            SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
            calCount = null;
            display = null;
        }

        public void OnLevelWasLoaded(int level)
        {

        }

        public void OnLevelWasInitialized(int level)
        {
        }

        public void OnUpdate()
        {
        }

        public void OnFixedUpdate()
        {
        }
    }
}
