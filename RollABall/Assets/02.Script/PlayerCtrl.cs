using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;
    public Text ExitText;

    private Rigidbody rb;
    private int count;
    float timer;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        timer = 15.0f;
        countText.text = "Count: " + count.ToString();
        winText.text = "";
        ExitText.text = "Exit Time: " + (15.0f - timer).ToString();
        
    }

    void FixedUpdate()
    {
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
        timer -= Time.deltaTime;

        SetExitText();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))  // 충돌한물체 : other가 태그가 픽업이면~
        {
            other.gameObject.SetActive(false); //other의 활동을 false(안보이게)로 바꿈
            count = count + 1;                 //통과할때 카운트 +1
            SetCountText();                    //SetCountText() 함수호출
            
        }
        
    }

    void SetCountText()                         //정수형 count 텍스트형 public으로 선언한 텍스트형 countText를 Count : 로 바꾸고 +
    {
        countText.text = "Count: " + count.ToString(); //count는 정수형이니깐 string으로 변경해서 더해준다.
        if (count >= 12)
        {
            winText.text = "You Win";
            this.enabled = false;
        }
    }

    void SetExitText()
    {
        ExitText.text = "Exit Time: " + timer.ToString();
        if (timer <= 0f)
        {
            winText.text = "You Lose";
            this.enabled = false;
        }
        
    }

    

}

