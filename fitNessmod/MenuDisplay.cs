using IllusionPlugin;
using System;
using UnityEngine;
using TMPro;

namespace fitNessmod
{
    class MenuDisplay : MonoBehaviour
    {
        
        public static Vector3 menuPosition = new Vector3(0f, 0.3f, 1.25f);
        public static Quaternion slantBottom = Quaternion.Euler(30, 0, 0);
        private int lifeCalories = ModPrefs.GetInt("fitNessMod", "lifeCalories", 0, true);
        private int dailyCalories = ModPrefs.GetInt("fitNessMod", "dailyCalories", 0, true);
        private int currentSessionCals = ModPrefs.GetInt("fitNessMod", "sessionCalories", 0, true);
        private string rdCals = ModPrefs.GetString("fitNessMod", "date", "dd.MM.yyyy", true);
        private string version = ModPrefs.GetString("fitNessMod", "version", "-.-.-", false);
        GameObject countCSC;
        GameObject countLC;
        GameObject countDC;
        public static TextMeshPro countLGC { get; set; } //Last Game
        public static TextMeshPro cscText { get; set; }
        public static TextMeshPro lcText { get; set; }
        public static TextMeshPro dcText { get; set; }
        public static TextMeshPro lgcText { get; set; }
        public static TextMeshPro labelLG { get; set; }

        void Awake()
        {
            Init();
        }
        void Init()
        {
            string currentDate = DateTime.Now.ToString("dd.MM.yyyy");
            if (rdCals != currentDate)
            {
                Console.WriteLine("Current date being set to: " + currentDate + ". Setting daily calorie count to zero;");
                dailyCalories = 0;
                ModPrefs.SetInt("fitNessMod", "dailyCalories", dailyCalories);

            }  
            //Init Current Session Counter #
            /////////////////////////////////////////////////////////////////////////
            cscText = this.gameObject.AddComponent<TextMeshPro>();
            cscText.text = ModPrefs.GetInt("fitNessMod", "sessionCalories", 0, true).ToString();
            cscText.fontSize = 2;
            cscText.color = Color.cyan;
            cscText.font = Resources.Load<TMP_FontAsset>("Beon SDF No-Glow");
            cscText.alignment = TextAlignmentOptions.Center;
            cscText.rectTransform.position = menuPosition + new Vector3(-1, -0.2f, 0);
            cscText.rectTransform.rotation = slantBottom;

            //Init Current Sesion Counter Label
            /////////////////////////////////////////////////////////////////////////
            countCSC = new GameObject("countCSClabel");
            TextMeshPro labelcsc = countCSC.AddComponent<TextMeshPro>();
            labelcsc.text = "Current Session Calories";
            labelcsc.fontSize = 1;
            labelcsc.color = Color.white;
            labelcsc.font = Resources.Load<TMP_FontAsset>("Beon SDF No-Glow");
            labelcsc.alignment = TextAlignmentOptions.Center;
            labelcsc.rectTransform.position = menuPosition + new Vector3(-1f, 0, 0);
            labelcsc.rectTransform.rotation = slantBottom;
            /////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////
            //Init Life Calories Counter #
            /////////////////////////////////////////////////////////////////////////
            lcText = new GameObject("lifeCalories").gameObject.AddComponent<TextMeshPro>();
            lcText.text = ModPrefs.GetInt("fitNessMod", "lifeCalories", 0, true).ToString();
            lcText.fontSize = 2;
            lcText.color = Color.cyan;
            lcText.font = Resources.Load<TMP_FontAsset>("Beon SDF No-Glow");
            lcText.alignment = TextAlignmentOptions.Center;
            lcText.rectTransform.position = menuPosition + new Vector3(1, -0.2f, 0);
            lcText.rectTransform.rotation = slantBottom;

            //Init Life Calories Counter Label
            /////////////////////////////////////////////////////////////////////////
            countLC = new GameObject("countLClabel");
            TextMeshPro labelLC = countLC.AddComponent<TextMeshPro>();
            labelLC.text = "All Calories";
            labelLC.fontSize = 1;
            labelLC.color = Color.white;
            labelLC.font = Resources.Load<TMP_FontAsset>("Beon SDF No-Glow");
            labelLC.alignment = TextAlignmentOptions.Center;
            labelLC.rectTransform.position = menuPosition + new Vector3(1, 0, 0);
            labelLC.rectTransform.rotation = slantBottom;
            /////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////
            //Init Daily Calories Counter #
            /////////////////////////////////////////////////////////////////////////
            dcText = new GameObject("dailyCalories").gameObject.AddComponent<TextMeshPro>();
            dcText.text = ModPrefs.GetInt("fitNessMod", "dailyCalories", 0, true).ToString();
            dcText.fontSize = 2;
            dcText.color = Color.cyan;
            dcText.font = Resources.Load<TMP_FontAsset>("Beon SDF No-Glow");
            dcText.alignment = TextAlignmentOptions.Center;
            dcText.rectTransform.position = menuPosition + new Vector3(0, -0.2f, 0);
            dcText.rectTransform.rotation = slantBottom;

            //Init Daily Calories Counter Label
            /////////////////////////////////////////////////////////////////////////
            countDC = new GameObject("countDClabel");
            TextMeshPro labelDC = countDC.AddComponent<TextMeshPro>();
            labelDC.text = "Daily Calories";
            labelDC.fontSize = 1;
            labelDC.color = Color.white;
            labelDC.font = Resources.Load<TMP_FontAsset>("Beon SDF No-Glow");
            labelDC.alignment = TextAlignmentOptions.Center;
            labelDC.rectTransform.position = menuPosition + new Vector3(0, 0, 0);
            labelDC.rectTransform.rotation = slantBottom;
            /////////////////////////////////////////////////////////////////////////



            //Init Last Game Calories Counter #
            /////////////////////////////////////////////////////////////////////////
            lgcText = new GameObject("dailyCalories").gameObject.AddComponent<TextMeshPro>();
            lgcText.text = "";
            lgcText.fontSize = 2;
            lgcText.color = Color.cyan;
            lgcText.font = Resources.Load<TMP_FontAsset>("Beon SDF No-Glow");
            lgcText.alignment = TextAlignmentOptions.Center;
            lgcText.rectTransform.position = menuPosition + new Vector3(2.5f, -0.6f, 0f);
            lgcText.rectTransform.rotation = Quaternion.Euler(0, 60, 0);

            //Init Last Game Song name Label
            /////////////////////////////////////////////////////////////////////////
            countLGC = new GameObject("countLGClabel").gameObject.AddComponent<TextMeshPro>();
            countLGC.text = version;
            countLGC.fontSize = 1.5f;
            countLGC.color = Color.white;
            countLGC.font = Resources.Load<TMP_FontAsset>("Beon SDF No-Glow");
            countLGC.alignment = TextAlignmentOptions.Center;
            countLGC.rectTransform.position = menuPosition + new Vector3(2.5f, -0.4f, 0f);
            countLGC.rectTransform.rotation = Quaternion.Euler(0, 60, 0);
            /////////////////////////////////////////////////////////////////////////
            //Init Last Game Calories Counter Label
            /////////////////////////////////////////////////////////////////////////

            labelLG = new GameObject("countLGClabel").gameObject.AddComponent<TextMeshPro>();
            labelLG.text = "Fitness Mod";
            labelLG.fontSize = 2f;
            labelLG.color = Color.white;
            labelLG.font = Resources.Load<TMP_FontAsset>("Beon SDF No-Glow");
            labelLG.alignment = TextAlignmentOptions.Center;
            labelLG.rectTransform.position = menuPosition + new Vector3(2.5f, -0.2f, 0f);
            labelLG.rectTransform.rotation = Quaternion.Euler(0, 60, 0);
            /////////////////////////////////////////////////////////////////////////
        }

        void OnDestroy()
        {
            Console.WriteLine("[fitNessMod | LOG] Destroying menuDisplay...");
        }

    }
}
