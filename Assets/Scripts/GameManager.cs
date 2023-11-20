using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public RectTransform mainButtons;
    public RectTransform transformButtons;
    public RectTransform animationButtons;
    public GameObject character;
    public GameObject character2;
    public Material targetMaterial;
    public Material targetMaterial2;
    public Texture[] texturesList;
    public Texture[] texturesList2;
    private Animator animator;
    private float duration = 1f;
    private int rotationCount = 0;
    private int textureListCount = 0;
    private bool char2 = false;
    private GameObject currentCharacter;

    // Start is called before the first frame update
    void Start()
    {
        currentCharacter = character;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //main buttons
    public void getTransformButtons()
    {
        mainButtons.transform.DOLocalMove(new Vector3(1425f, -745f, 0f), duration);
        transformButtons.transform.DOLocalMove(new Vector3(0f, -718f, 0f), duration);
    }

    public void getAnimationButtons()
    {
        animator = currentCharacter.GetComponent<Animator>();
        Sequence sequence = DOTween.Sequence();
        sequence.Append(mainButtons.transform.DOLocalMove(new Vector3(0f, -1575f, 0f), duration));
        sequence.Append(animationButtons.transform.DOLocalMove(new Vector3(0f, -718f, 0f), duration));
        sequence.Play();
    }

    //customize button
    void ChangeAlbedoTexture(int textureIndex)
    {
        if (currentCharacter == character)
        {
            if (targetMaterial != null && textureIndex >= 0 && textureIndex < texturesList.Length)
            {
                targetMaterial.SetTexture("_MainTex", texturesList[textureIndex]);
            }
        }
        else
        {
            if (targetMaterial2 != null && textureIndex >= 0 && textureIndex < texturesList2.Length)
            {
                targetMaterial2.SetTexture("_MainTex", texturesList2[textureIndex]);
            }
        }
    }

    public void changeCharColor()
    {
        textureListCount++;
        if (currentCharacter == character)
        {
            if (textureListCount >= texturesList.Length)
            {
                textureListCount = 0;
            }
            ChangeAlbedoTexture(textureListCount);
        } else
        {
            if (textureListCount >= texturesList2.Length)
            {
                textureListCount = 0;
            }
            ChangeAlbedoTexture(textureListCount);
        }
    }

    //change model

    void resetValues()
    {
        Vector3 defaultScale = Vector3.one;
        Vector3 defaultRotation = Vector3.zero;
        character.transform.DORotate(defaultRotation, 0);
        character2.transform.DORotate(defaultRotation, 0);
        character.transform.DOScale(defaultScale, 0);
        character2.transform.DOScale(defaultScale, 0);
        rotationCount = 0;
        textureListCount = 0;
        ChangeAlbedoTexture(textureListCount);
    }

    public void switchChars()
    {
        if (char2 == false)
        {
            character.SetActive(false);
            character2.SetActive(true);
            currentCharacter = character2;
            resetValues();
            char2 = true;
        } else
        {
            character2.SetActive(false);
            character.SetActive(true);
            currentCharacter = character;
            resetValues();
            char2 = false;
        }
    }

    //transform button functions
    public void transformBack()
    {
        mainButtons.transform.DOLocalMove(new Vector3(0f, -794f, 0f), duration);
        transformButtons.transform.DOLocalMove(new Vector3(-1425f, -718f, 0f), duration);
    }

    public void rotateChar()
    {
        rotationCount++;
        float targetRotation = rotationCount * 90;
        currentCharacter.transform.DORotate(new Vector3(0f, targetRotation, 0f), duration);
    }

    public void scaleUpChar()
    {
        float targetScale = Mathf.Min(2.0f, currentCharacter.transform.localScale.x + 0.1f);
        currentCharacter.transform.DOScale(new Vector3(targetScale, targetScale, targetScale), 0f);
    }

    public void scaleDownChar()
    {
        float targetScale = Mathf.Max(0.1f, currentCharacter.transform.localScale.x - 0.1f);
        currentCharacter.transform.DOScale(new Vector3(targetScale, targetScale, targetScale), 0f);
    }

    //animation buttons

    public void animationBack()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(animationButtons.transform.DOLocalMove(new Vector3(0f, -1575f, 0f), duration));
        sequence.Append(mainButtons.transform.DOLocalMove(new Vector3(0f, -794f, 0f), duration));
        sequence.Play();
    }

    public void animationWave()
    {
        animator.SetTrigger("Wave");
    }

    public void animationWalk()
    {
        animator.SetTrigger("Walk");
    }

    public void animationDance()
    {
        animator.SetTrigger("Dance");
    }
}
