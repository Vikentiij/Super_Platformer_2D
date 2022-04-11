using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Slideshow : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> imagesForShow;

    [SerializeField]
    private float slideshowInterval = 2f;

    [SerializeField]
    string nextScene;

    private float currentSlideTime;
    private int indexImagesForShow = 0;

    private Image imgShow;

    // Start is called before the first frame update
    void Start()
    {
        imgShow = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        currentSlideTime -= Time.deltaTime;

        if (currentSlideTime <= 0)
        {
            if (indexImagesForShow > imagesForShow.Count - 1)
            {
                SceneManager.LoadScene(nextScene);
            }
            else
            {
                imgShow.sprite = imagesForShow[indexImagesForShow];
                indexImagesForShow++;
                currentSlideTime = slideshowInterval;
            }
        }
    }
}
