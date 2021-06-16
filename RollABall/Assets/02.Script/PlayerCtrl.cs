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
        if (other.gameObject.CompareTag("Pick Up"))  // �浹�ѹ�ü : other�� �±װ� �Ⱦ��̸�~
        {
            other.gameObject.SetActive(false); //other�� Ȱ���� false(�Ⱥ��̰�)�� �ٲ�
            count = count + 1;                 //����Ҷ� ī��Ʈ +1
            SetCountText();                    //SetCountText() �Լ�ȣ��
            
        }
        
    }

    void SetCountText()                         //������ count �ؽ�Ʈ�� public���� ������ �ؽ�Ʈ�� countText�� Count : �� �ٲٰ� +
    {
        countText.text = "Count: " + count.ToString(); //count�� �������̴ϱ� string���� �����ؼ� �����ش�.
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

