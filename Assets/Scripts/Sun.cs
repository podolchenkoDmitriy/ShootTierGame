using UnityEngine;

public class Sun : MonoBehaviour
{
    public float rotatingSpeed = 10f;
    public Material mat;
    [Header("SpeedToChangeColors")]

    [Range(1, 10f)]
    public float speedToChangeDayNight = 1f;
    [Space]
    [Header("DayColors")]
    public Color skyBoxTopColor;
    public Color skyBoxBotColor;
    public Color skyBoxLitColor;
    public GameObject stars;
    [Header("NightColors")]
    public Color nightTopColor;
    public Color nightBotColor;
    public Color nightLitColor;
    [Space]

    [Header("earlyMorningColors")]
    public Color earlyMorningTopColor;
    public Color earlyMorningBotColor;
    public Color earlyLitBotColor;
    [Space]
    [Header("EveningColors")]
    public Color eveningTopColor;
    public Color eveningBotColor;
    public Color eveningLitColor;
    [Space]
    [Header("DeepNightColors")]
    public Color deepNightTopColor;
    public Color deepNightBotColor;
    public Color deepNightLitColor;

    public float yPosToChangeDayNight = 6000;
    Color[] colorArr;

    public Light[] lights;

    // Update is called once per frame
    private void Start()
    {
        
       // ChangeColorForLevel();

    }

    private bool morning = false;
    private void Update()
    {
        transform.RotateAround(Vector3.zero, Vector3.right, rotatingSpeed * Time.deltaTime);
        transform.LookAt(Vector3.zero);

        if (transform.position.y < 0)
        {
            if (transform.position.y > -yPosToChangeDayNight && mat.GetColor("_ColorMid") != nightTopColor && !morning)
            {
                ChangeMat(nightTopColor, nightBotColor);
                if (!stars.activeInHierarchy)
                {
                    stars.SetActive(true);
                    LoopParticle();

                }
                else if (stars.GetComponent<ParticleSystem>().isStopped)
                {
                    stars.GetComponent<ParticleSystem>().Play();
                    LoopParticle();

                }

            }
            else if (mat.GetColor("_ColorMid") != deepNightTopColor)
            {
                ChangeMat(deepNightTopColor, deepNightBotColor);
                if (!morning)
                {
                    morning = true;
                }
            }

        }
        else
        {

            if (transform.position.y > yPosToChangeDayNight && mat.GetColor("_ColorMid") != skyBoxTopColor)
            {
                ChangeMat(skyBoxTopColor, skyBoxBotColor);

                if (morning)
                {
                    morning = false;
                }

            }

            else if (mat.GetColor("_ColorMid") != earlyMorningBotColor && morning)
            {
                ChangeMat(earlyMorningTopColor, earlyMorningBotColor);


            }
            else if (!morning)
            {
                ChangeMat(eveningTopColor, eveningBotColor);


            }


        }

    }

    private void LoopParticle()
    {
        if (PlayerPrefs.GetInt("Level") > 15)
        {
            var main = stars.GetComponent<ParticleSystem>().main;
            main.loop = true;
        }
    }

    private void ChangeMat(Color TopCol, Color BotCol)
    {
        Color lightCol = new Color();
        if (BotCol == skyBoxBotColor)
        {
            lightCol = skyBoxLitColor;
        }
        if (BotCol == nightBotColor)
        {
            lightCol = nightLitColor;
        }
        if (BotCol == earlyMorningBotColor)
        {
            lightCol = earlyLitBotColor;
        }
        if (BotCol == eveningBotColor)
        {
            lightCol = eveningLitColor;
        }
        if (BotCol == deepNightBotColor)
        {
            lightCol = deepNightLitColor;
        }

        foreach (Light item in lights)
        {
            item.color = Color.Lerp(item.color, lightCol, speedToChangeDayNight * Time.deltaTime / 10);
        }
        mat.SetColor("_ColorMid", Color.Lerp(mat.GetColor("_ColorMid"), TopCol, speedToChangeDayNight * Time.deltaTime / 10));
        mat.SetColor("_ColorBot", Color.Lerp(mat.GetColor("_ColorBot"), BotCol, speedToChangeDayNight * Time.deltaTime / 10));
    }



    private void OnApplicationQuit()
    {
        mat.SetColor("_ColorMid", skyBoxTopColor);
        mat.SetColor("_ColorBot", skyBoxBotColor);
    }
    const float coefForDeterm = 0.05f;
    Color newCol(Color col, int k)
    {
        col += new Color(col.r * (coefForDeterm * k), col.g * (coefForDeterm * k), col.b * (coefForDeterm * k));
        return col;
    }
    private void ChangeColorForLevel()
    {
        int k = PlayerPrefs.GetInt("Level");

        if (k > 0)
        {
            skyBoxTopColor -= new Color(skyBoxTopColor.r * (coefForDeterm * k), skyBoxTopColor.g * (coefForDeterm * k), skyBoxTopColor.b * (coefForDeterm * k));

            skyBoxBotColor -= new Color(skyBoxBotColor.r * (coefForDeterm * k), skyBoxBotColor.g * (coefForDeterm * k), skyBoxBotColor.b * (coefForDeterm * k));
            nightTopColor -= new Color(nightTopColor.r * (coefForDeterm * k), nightTopColor.g * (coefForDeterm * k), nightTopColor.b * (coefForDeterm * k));

            nightBotColor -= new Color(nightBotColor.r * (coefForDeterm * k), nightBotColor.g * (coefForDeterm * k), nightBotColor.b * (coefForDeterm * k));

            earlyMorningTopColor -= new Color(earlyMorningTopColor.r * (coefForDeterm * k), earlyMorningTopColor.g * (coefForDeterm * k), earlyMorningTopColor.b * (coefForDeterm * k));

            earlyMorningBotColor -= new Color(earlyMorningBotColor.r * (coefForDeterm * k), earlyMorningBotColor.g * (coefForDeterm * k), earlyMorningBotColor.b * (coefForDeterm * k));

            eveningTopColor -= new Color(eveningTopColor.r * (coefForDeterm * k), eveningTopColor.g * (coefForDeterm * k), eveningTopColor.b * (coefForDeterm * k));

            eveningBotColor -= new Color(eveningBotColor.r * (coefForDeterm * k), eveningBotColor.g * (coefForDeterm * k), eveningBotColor.b * (coefForDeterm * k));

            deepNightTopColor -= new Color(deepNightTopColor.r * (coefForDeterm * k), deepNightTopColor.g * (coefForDeterm * k), deepNightTopColor.b * (coefForDeterm * k));

            deepNightBotColor -= new Color(deepNightBotColor.r * (coefForDeterm * k), deepNightBotColor.g * (coefForDeterm * k), deepNightBotColor.b * (coefForDeterm * k));



        }
    }


}
