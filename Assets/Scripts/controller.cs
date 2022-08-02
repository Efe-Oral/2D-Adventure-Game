using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    public float speed = 1f;
    private Rigidbody2D r2d;
    private Animator _animator;
    private Vector3 charPos;
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private GameObject _camera; // SerializeField değikenleri editörde görüntülenebilir hale gelir

    void Start()// Start is called before the first frame update !!!!!!İLK BURASI ÇALIŞIR!!!!!!
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        r2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        charPos = transform.position;
    }

    private void Fixedupdate() //fizik hesaplamalarının yapıldığı fonks. !!!!!!İKİNCİ BURASI ÇALIŞIR!!!!!!
    {
        //r2d.velocity = new Vector2(speed,0f); 
        //_camera.transform.position = new Vector3(charPos.x,charPos.y,charPos.z - 1.0f); // you can do this but not recommended
    }
    
    void Update() // Update is called once per frame  !!!!!!ÜÇÜNCÜ BURASI ÇALIŞIR!!!!!!
    {
        Debug.Log(Input.GetAxis("Horizontal"));
        /*if (Input.GetKey(KeyCode.Space))
        {
            speed = 1.0f;
            //Debug.Log("Hiz 1.0f");
        }
        else
        {
            speed = 0.0f;
            //Debug.Log("Hiz 0f");
        }*/
        charPos = new Vector3(charPos.x + (Input.GetAxis("Horizontal")*speed*Time.deltaTime),charPos.y,charPos.z); // karakterin konumu burada değişiyor
        transform.position = charPos;
        
        if(Input.GetAxis("Horizontal") == 0.0f)
        {
            _animator.SetFloat("speed", 0.0f);
        }
        else
        {
            _animator.SetFloat("speed", 1.0f);
        }
        if(Input.GetAxis("Horizontal") > 0.01f)
        {
            _spriteRenderer.flipX = false;
        }
        else if(Input.GetAxis("Horizontal") < -0.01f)
        {
            _spriteRenderer.flipX = true;
        }
        //r2d.velocity = new Vector2(speed,0f); // kendi girdiğimiz speed parametresini hız olarak atar
    }
    private void LateUpdate()  // !!!!!!DÖRDÜNCÜ BURASI ÇALIŞIR!!!!!!
    {
        _camera.transform.position = new Vector3(charPos.x,charPos.y,charPos.z - 1.0f);
    }
}
