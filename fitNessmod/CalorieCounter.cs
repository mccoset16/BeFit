using IllusionPlugin;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;

namespace fitNessmod
{
    class CalorieCounter : MonoBehaviour
    {
        private ScoreController saberRating;
        private StandardLevelSceneSetupDataSO lvlData;
        float counter = 0;
        public int calories = 0;
        private int lifeCalories = ModPrefs.GetInt("fitNessMod", "lifeCalories", 0, true);
        private int dailyCalories = ModPrefs.GetInt("fitNessMod", "dailyCalories", 0, true);
        private int currentSessionCals = ModPrefs.GetInt("fitNessMod", "sessionCalories", 0, true);
        float bladespeed;
        float calMul = 0.07676767f; //Determines Calories per hit by swing rating. [0.07676767, 0.9] tested range
        GameObject countGo;
        TextMeshPro counterText;

        async void Awake()
        {
            ModPrefs.SetString("fitNessMod", "date", DateTime.Now.ToString("dd.MM.yyyy"));
            await GetCalories();
        }
        Task GetCalories()
        {
            return Task.Run(() => {
                while (true)
                {
                    lvlData = Resources.FindObjectsOfTypeAll<StandardLevelSceneSetupDataSO>().FirstOrDefault();
                    saberRating = Resources.FindObjectsOfTypeAll<ScoreController>().FirstOrDefault();
                    if (saberRating != null) break;
                    Thread.Sleep(10);
                }
                Init();
            });
        }

        void Init()
        {
            counterText = this.gameObject.AddComponent<TextMeshPro>();
            counterText.text = "0";
            counterText.fontSize = 4;
            counterText.color = Color.cyan;
            counterText.font = Resources.Load<TMP_FontAsset>("Beon SDF No-Glow");
            counterText.alignment = TextAlignmentOptions.Center;
            counterText.rectTransform.position = Plugin.counterPosition + new Vector3(0, -0.4f, 0);

            countGo = new GameObject("Label");
            TextMeshPro label = countGo.AddComponent<TextMeshPro>();
            label.text = "Calories";
            label.fontSize = 3;
            label.color = Color.white;
            label.font = Resources.Load<TMP_FontAsset>("Beon SDF No-Glow");
            label.alignment = TextAlignmentOptions.Center;
            label.rectTransform.position = Plugin.counterPosition;

            if (saberRating != null)
            {
                saberRating.noteWasCutEvent += onNoteCut;
                saberRating.noteWasMissedEvent += onNoteMiss;
            }

        }
        void OnDestroy()
        {
            MenuDisplay.countLGC.text = lvlData.difficultyBeatmap.level.songName;
            MenuDisplay.labelLG.text = "Last Played Song";
            MenuDisplay.lgcText.text = (calories).ToString();
            MenuDisplay.cscText.text = (currentSessionCals + calories).ToString();
            MenuDisplay.lcText.text = (lifeCalories + calories).ToString();
            MenuDisplay.dcText.text = (dailyCalories + calories).ToString();
            ModPrefs.SetInt("fitNessMod", "lifeCalories", lifeCalories + calories);
            ModPrefs.SetInt("fitNessMod", "dailyCalories", dailyCalories + calories);
            ModPrefs.SetInt("fitNessMod", "sessionCalories", currentSessionCals + calories);
            Console.WriteLine("[fitNessMod | LOG] Current Calories: " + ModPrefs.GetInt("fitNessMod", "sessionCalories", 0, true));
            saberRating.noteWasCutEvent -= onNoteCut;
            saberRating.noteWasMissedEvent -= onNoteMiss;
        }

        private void onNoteCut(NoteData data, NoteCutInfo info, int c)
        {
            bladespeed = info.swingRating;
            calculateCalorie(bladespeed);
        }

        private void onNoteMiss(NoteData data, int c)
        {
            bladespeed = bladespeed / 1.75f; 
            calculateCalorie(bladespeed);
        }

        private void calculateCalorie(float speed)
        {
            float caloriesBurned =  speed * calMul;

            incrementCounter(caloriesBurned);
        }

        private void incrementCounter(float cals)
        {
            counter +=  cals; //float count for small increments
            calories = (int) counter; //int count for visibility
            counterText.text = calories.ToString();
            if(calories > 15)
            {
                counterText.color = Color.green;
            }
            if(calories > 25)
            {
                counterText.color = Color.magenta;
            }
            if(calories > 35)
            {
                counterText.color = Color.red;
            }
        }
    }
}
