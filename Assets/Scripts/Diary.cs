using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Diary : MenuBase
{
    private int liveChanterelle = 0;

    //вырезано
    private int wasp = 0;
    private int liveFlyAgaric = 0;

    private bool firstkill = false;

    //вырезано
    private bool killAll = false;

    [SerializeField] Tab tab;

    [SerializeField] private int numberOfPages;
    [SerializeField] private int currentPage;

    [SerializeField] private GameObject nextPage;
    [SerializeField] private GameObject previousPage;

    [SerializeField] TextMeshProUGUI header;
    [SerializeField] Image image;
    [SerializeField] TextMeshProUGUI description;

    [Header("Bestiary")]
    [SerializeField] private List<string> headersBestiary = new List<string>();
    [SerializeField] private List<string> descriptionsBestiary = new List<string>();
    [SerializeField] private List<Sprite> bestiaryImages = new List<Sprite>();

    [Header("Locations")]
    [SerializeField] private List<string> headersLocations = new List<string>();
    [SerializeField] private List<string> descriptionsLocations = new List<string>();
    [SerializeField] private List<Sprite> locationsImages = new List<Sprite>();


    [Header("Resources")]
    [SerializeField] private List<string> headersResources = new List<string>();
    [SerializeField] private List<string> descriptionsResources = new List<string>();
    [SerializeField] private List<Sprite> resourcesImages = new List<Sprite>();

    [Header("Story")]
    [SerializeField] private List<string> headersStory = new List<string>();
    [SerializeField] private List<string> descriptionsStory = new List<string>();
    [SerializeField] private List<Sprite> storyImages = new List<Sprite>();

    [Header("Recipes")]
    [SerializeField] private List<string> headersRecipes = new List<string>();
    [SerializeField] private List<string> descriptionsRecipes = new List<string>();
    [SerializeField] private List<Sprite> recipesImages = new List<Sprite>();

    [Header("Training")]
    [SerializeField] private List<string> headersTraining = new List<string>();
    [SerializeField] private List<string> descriptionsTraining = new List<string>();
    [SerializeField] private List<Sprite> trainingImages = new List<Sprite>();


    private void OnEnable()
    {
        HintConclusion("Ќажмите H");
    }

    private void Start()
    {


        switch (tab)
        {
            case Tab.Bestiary:
                SwitchBestiaryTab();
                break;
            case Tab.Locations:
                SwitchLocationsTab();
                break;
            case Tab.Resources:
                SwitchResourcesTab();
                break;
            case Tab.Story:
                SwitchStoryTab();
                break;
            case Tab.Recipes:
                SwitchRecipesTab();
                break;
            case Tab.Training:
                SwitchTrainingTab();
                break;

        }

        ButtonActive();
    }


    public void SwitchBestiaryTab()
    {
        image.sprite = bestiaryImages[0];
        header.text = headersBestiary[0];
        description.text = descriptionsBestiary[0];
        numberOfPages = headersBestiary.Count;
        currentPage = 0;
        tab = Tab.Bestiary;
        ButtonActive();
    }

    public void SwitchLocationsTab()
    {
        image.sprite = locationsImages[0];
        header.text = headersLocations[0];
        description.text = descriptionsLocations[0];
        numberOfPages = headersLocations.Count;
        currentPage = 0;
        tab = Tab.Locations;
        ButtonActive();
    }

    public void SwitchResourcesTab()
    {
        image.sprite = resourcesImages[0];
        header.text = headersResources[0];
        description.text = descriptionsResources[0];
        numberOfPages = headersResources.Count;
        currentPage = 0;
        tab = Tab.Resources;
        ButtonActive();
    }

    public void SwitchStoryTab()
    {
        image.sprite = storyImages[0];
        header.text = headersStory[0];
        description.text = descriptionsStory[0];
        numberOfPages = headersStory.Count;
        currentPage = 0;
        tab = Tab.Story;
        ButtonActive();
    }

    public void SwitchRecipesTab()
    {
        image.sprite = recipesImages[0];
        header.text = headersRecipes[0];
        description.text = descriptionsRecipes[0];
        numberOfPages = headersRecipes.Count;
        currentPage = 0;
        tab = Tab.Recipes;
        ButtonActive();
    }

    public void SwitchTrainingTab()
    {
        image.sprite = trainingImages[0];
        header.text = headersTraining[0];
        description.text = descriptionsTraining[0];
        numberOfPages = headersTraining.Count;
        currentPage = 0;
        tab = Tab.Training;
        ButtonActive();
    }

    public void NextPage()
    {
        switch (tab)
        {
            case Tab.Bestiary:
                if (currentPage < numberOfPages - 1)
                {
                    currentPage++;
                    header.text = headersBestiary[currentPage];
                    description.text = descriptionsBestiary[currentPage];
                    image.sprite = bestiaryImages[currentPage];
                }
                break;

            case Tab.Locations:
                if (currentPage < numberOfPages - 1)
                {
                    currentPage++;
                    header.text = headersLocations[currentPage];
                    description.text = descriptionsLocations[currentPage];
                    image.sprite = locationsImages[currentPage];
                }
                break;

            case Tab.Resources:
                if (currentPage < numberOfPages - 1)
                {
                    currentPage++;
                    header.text = headersResources[currentPage];
                    description.text = descriptionsResources[currentPage];
                    image.sprite = resourcesImages[currentPage];
                }
                break;

            case Tab.Story:
                if (currentPage < numberOfPages - 1)
                {
                    currentPage++;
                    header.text = headersStory[currentPage];
                    description.text = descriptionsStory[currentPage];
                    image.sprite = storyImages[currentPage];
                }
                break;
            case Tab.Recipes:
                if (currentPage < numberOfPages - 1)
                {
                    currentPage++;
                    header.text = headersRecipes[currentPage];
                    description.text = descriptionsRecipes[currentPage];
                    image.sprite = recipesImages[currentPage];
                }
                break;
            case Tab.Training:
                if (currentPage < numberOfPages - 1)
                {
                    currentPage++;
                    header.text = headersTraining[currentPage];
                    description.text = descriptionsTraining[currentPage];
                    image.sprite = trainingImages[currentPage];

                }
                break;
        }

        ButtonActive();
    }

    public void PreviousPage()
    {
        switch (tab)
        {
            case Tab.Bestiary:
                if (currentPage > 0)
                {
                    currentPage--;
                    header.text = headersBestiary[currentPage];
                    description.text = descriptionsBestiary[currentPage];
                    image.sprite = bestiaryImages[currentPage];
                }
                break;

            case Tab.Locations:
                if (currentPage > 0)
                {
                    currentPage--;
                    header.text = headersLocations[currentPage];
                    description.text = descriptionsLocations[currentPage];
                    image.sprite = locationsImages[currentPage];
                }
                break;

            case Tab.Resources:
                if (currentPage > 0)
                {
                    currentPage--;
                    header.text = headersResources[currentPage];
                    description.text = descriptionsResources[currentPage];
                    image.sprite = resourcesImages[currentPage];
                }
                break;

            case Tab.Story:
                if (currentPage > 0)
                {
                    currentPage--;
                    header.text = headersStory[currentPage];
                    description.text = descriptionsStory[currentPage];
                    image.sprite = storyImages[currentPage];
                }
                break;

            case Tab.Recipes:
                if (currentPage > 0)
                {
                    currentPage--;
                    header.text = headersRecipes[currentPage];
                    description.text = descriptionsRecipes[currentPage];
                    image.sprite = recipesImages[currentPage];
                }
                break;

            case Tab.Training:
                if (currentPage > 0)
                {
                    currentPage--;
                    header.text = headersTraining[currentPage];
                    description.text = descriptionsTraining[currentPage];
                    image.sprite = trainingImages[currentPage];
                }
                break;
        }

        ButtonActive();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (open == false && Time.timeScale == 1)
            {
                OpenMenu();
            }
            else if (open == true && Time.timeScale == 0)
            {
                CloseMenu();
            }
        }
        if (open == true && Input.GetKeyUp(KeyCode.Escape))
        {
            CloseMenu();
        }
        if(image.sprite == null)
        {
            image.enabled = false;
        }
        else{
            image.enabled = true;
        }

    }

    private enum Tab
    {
        Bestiary,
        Locations,
        Resources, 
        Story,
        Recipes,
        Training

    }

    private void ButtonActive()
    {
        if (!(currentPage < numberOfPages - 1))
        {
            nextPage.SetActive(false);
        }
        else
        {
            nextPage.SetActive(true);
        }
        if (!(currentPage > 0))
        {
            previousPage.SetActive(false);
        }
        else
        {
            previousPage.SetActive(true);

        }
    }


    public void HandleLocationTrigger(Sprite ImageLocation, string headerLocations, string descriptionLocations)
    {

        headersLocations.Add(headerLocations);
        descriptionsLocations.Add(descriptionLocations);
        locationsImages.Add(ImageLocation);

        numberOfPages++;

        if (tab == Tab.Locations)
        {
            SwitchLocationsTab();
        }

        Debug.Log(headerLocations);
    }

    public void HandleStoryTrigger(Sprite ImageStory, string headerStory, string descriptionStory)
    {
        if(headerStory == "1")
        {
            headersStory.Add(" онец первого дн€");
            descriptionsStory.Add("“ут быстро темнеет, пришлось бежать на базу. ƒаже не помню обратную дорогу, так спешил. ќт ѕервопроходцев пришло три заказа, похоже скучно тут точно не будет.");
            storyImages.Add(null);

            numberOfPages++;

            if (tab == Tab.Story)
            {
                SwitchStoryTab();
            }

            Debug.Log(headerStory);
        }
        else if(headerStory == "2")
        {
            headersStory.Add(" онец второго дн€");
            descriptionsStory.Add("я вновь бежал на базу со всех ног. я заметил, что когда темнеет, здешние существа активизируютс€. Ќаверно они все ведут ночной образ жизни. ѕервопроходцы снова много заказали, а € не успел передать им информацию о своих похождени€х. «автра об€зательно им все расскажу.");
            storyImages.Add(null);

            numberOfPages++;

            if (tab == Tab.Story)
            {
                SwitchStoryTab();
            }

            Debug.Log(headerStory);
        }
        else
        {
            headersStory.Add(headerStory);
            descriptionsStory.Add(descriptionStory);
            storyImages.Add(ImageStory);

            numberOfPages++;

            if (tab == Tab.Story)
            {
                SwitchStoryTab();
            }

            Debug.Log(headerStory);
        }
    }

    public void HandleBestiaryTrigger(Sprite ImageBestiary, string headerBestiary, string descriptionBestiary, string name)
    {

        if ((name == "wasp" && wasp < 1) || (name == "liveChanterelle" && liveChanterelle < 1) || (name == "liveFlyAgaric" && liveFlyAgaric < 1))
        {
            headersBestiary.Add(headerBestiary);
            descriptionsBestiary.Add(descriptionBestiary);
            bestiaryImages.Add(ImageBestiary);

            numberOfPages++;

            if (tab == Tab.Story)
            {
                SwitchStoryTab();
            }

            Debug.Log(headerBestiary);
        }

        switch (name)
        {
            case "wasp":
                wasp++;
                break;
            case "liveChanterelle":
                liveChanterelle++;
                break;
            case "liveFlyAgaric":
                liveFlyAgaric++;
                break;
            case "Cristal":
                liveFlyAgaric++;
                break;
        }

        if (!firstkill && (wasp >= 1 || liveChanterelle >= 1 || liveFlyAgaric >= 1))
        {
            headersStory.Add("ƒика€ планета");
            descriptionsStory.Add("ѕланета оказалась не так гостеприиимна как ожидалось. ѕервопроходцы об этом не сообщали, неужели у их лагер€ нет таких опасностей? —пасибо папе, что заставл€л делать зар€дку, € смогу дать отпор любой угрозе!");
            storyImages.Add(null);
            firstkill = true;
            Debug.Log("firstkill");
        }
        //вырезано
        if (wasp >= 1 && liveChanterelle >= 1 && liveFlyAgaric >= 1 && !killAll)
        {
            headersStory.Add("‘лора и ‘ауна");
            descriptionsStory.Add("ћестные существа довольно опасны, но все же вызывают исследовательский интерес. ћожно ли выращивать живые лисички, чтобы собирать грибы, которые они кидают? ћожно ли из шл€пки брод€чего мухомора делать защиту дл€ наших ученых? »з чего же состо€т эти кристальные осы? “ак много вопросов, но так мало ответов...");
            storyImages.Add(null);
            killAll = true;
            Debug.Log("killAll");
        }
    }
}

