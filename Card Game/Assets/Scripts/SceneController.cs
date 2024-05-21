using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public const int gridRows = 2;
    public const int gridCols = 4;
    public const float offsetX = 2f;
    public const float offsetY = 2.5f;

    private int _score = 0;


    [SerializeField] MemoryCard originalCard;
    [SerializeField] Sprite[] images;
    [SerializeField] TMP_Text ScoreLabel;

    private MemoryCard _FirstRevealed;
    private MemoryCard _SecondRevealed;

    public bool canReveal 
    {
        get { return _SecondRevealed == null; }
    }

    public void CardRevealed(MemoryCard card)
    {
        if (_FirstRevealed == null)
        {
            _FirstRevealed = card;
        }
        else
        {
            _SecondRevealed = card;
            //Debug.Log("Match ?" + (_FirstRevealed.ID == _SecondRevealed.ID));
            StartCoroutine(_CheckMatch());
        }
    }

    private IEnumerator _CheckMatch()
    {
        if (_FirstRevealed.ID == _SecondRevealed.ID)
        {
            _score++;
            //Debug.Log("Score: " + _score);
            ScoreLabel.text = "Score: " + _score;
        }
        else
        {
            yield return new WaitForSeconds(0.5f);
            _FirstRevealed.Unreveal();
            _SecondRevealed.Unreveal();
        }

        _FirstRevealed = null;
        _SecondRevealed = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        //int id = Random.Range(0, images.Length);
        //originalCard.SetCard(id, images[id]);

        Vector3 startPos = originalCard.transform.position;

        int[] numbers = {0, 0, 1, 1, 2, 2, 3, 3};

        numbers = ShuffleArray(numbers);

        for( int i = 0; i <gridCols; i++ )
        {
            for (int j = 0; j <gridRows; j++)
            {
                MemoryCard card;
                if (i == 0 && j == 0)
                {
                    card = originalCard;
                }
                else
                {
                    card = Instantiate(originalCard) as MemoryCard;
                }
                //int id = Random.Range(0, images.Length);

                int index = j *gridCols + i;
                int id = numbers[index];
                card.SetCard(id, images[id]);

                float posX = (offsetX * i) + startPos.x;
                float posY = (offsetY * j) + startPos.y;
                card.transform.position = new Vector3(posX, posY, startPos.z);
            }
        }
    }

    private int[] ShuffleArray(int[] numbers)
    {
        int[] newArray = numbers.Clone() as int[];
        for (int i = 0; i < newArray.Length; i++)
        {
            int temp = newArray[i];
            int rand = Random.Range(i, newArray.Length);
            newArray[i] = newArray[rand];
            newArray[rand] = temp;

        }
        return newArray;
    }
    
    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
