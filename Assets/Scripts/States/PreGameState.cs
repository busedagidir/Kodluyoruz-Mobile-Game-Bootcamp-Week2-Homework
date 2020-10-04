using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PreGameState : MonoBehaviour, IState
{
    [SerializeField]
    private GameObject _waitScreen;
    [SerializeField]
    private TextMeshProUGUI _waitText;

    private bool _isStart;
    private Coroutine _coroutine;

    public void Enter()
    {
        _isStart = true;
        _coroutine = StartCoroutine(WaitForStart());
    }

    public void Exit()
    {
        _isStart = false;
        StopCoroutine(_coroutine);
        _waitScreen.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FindObjectOfType<GameManager>().SetState(StateType.GameState);
        }
    }

    private IEnumerator WaitForStart()
    {
        float t = 0;

        while (_isStart)
        {
            var val = Mathf.PingPong(t, 0.5f) + 0.5f;
            _waitText.color = new Color(1, 1, 1, val);
            yield return null;
            t += Time.deltaTime; 
        }
        
    }
}
