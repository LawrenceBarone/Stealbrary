using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BookContainer : MonoBehaviour
{
    TextMeshProUGUI numberOfBooksTxt;
    [SerializeField] int _nbOfBooks = 1;
    [SerializeField] int _totalNbOfBooks = 1;

    bool regenerate = false;

    private void Start()
    {
        numberOfBooksTxt = GetComponentInChildren<TextMeshProUGUI>();
        ShowNbOfBooks();
    }
    public int GetABook()
    {
        Debug.Log("CALLED : " + _nbOfBooks);
        return _nbOfBooks;
     }
    public void UpdateNbOfBooks()
    {
        if (_nbOfBooks > 0)
        {
            _nbOfBooks--;
            ShowNbOfBooks();
        }
    }

    private void FixedUpdate()
    {
        if (_totalNbOfBooks > _nbOfBooks)
        {
            regenerate = true;
            RegenerateBook();
        }
        else regenerate = false;
    }

    void RegenerateBook()
    {
        if (regenerate)
        {
            _nbOfBooks++;
            ShowNbOfBooks();
        }
    }

    void ShowNbOfBooks()
    {
        numberOfBooksTxt.text = _nbOfBooks.ToString();
    }
}
