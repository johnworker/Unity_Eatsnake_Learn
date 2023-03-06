using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    #region �򥻳g�Y�D�s�@
    /*�o�ӵ{���X�ϥ� Unity �����ӹ�{ 3D ���g�Y�D�C���C��C���}�l�ɡA Start �禡�|�Q����ó]�m�g�Y�D����l�t�ץH�β����W�v�C Move �禡�Q���ƽեΡA�ϳg�Y�D�C�Ӯɶ����j�V��e��V���ʤ@��A�ç�s�g�Y�D�����ڡCUpdate �禡�h�B�z���a�������J�ӧ��ܳg�Y�D�����ʤ�V�C�p�G�g�Y�D���쭹���A�h�ͦ��@�ӷs�����ڨçR�������C�p�G�g�Y�D����ۤv�����ڡA�h�C�����s�}�l�C�ݭn�`�N���O�A3D ���g�Y�D�����ʤ�V�O����Ӥ��O�����C�]���A�b Update �禡���A���a���U���Υk�b�Y�ɡA�g�Y�D�|�V���Υk���� 90 �סC�P�ɡA�g�Y�D�����ڤ]�ݭn�ϥΰ}�C�Ӧs�x�A�Ӥ��O�ϥΦC��C*/
    #endregion

    // �ŧi�ܼ�
    public float speed = 1f;
    public GameObject tailPrefab;
    private Transform[] tailList;
    private int tailLength = 0;

    // �}�l�ɰ���
    void Start()
    {
        tailList = new Transform[100];
        InvokeRepeating("Move", 0.1f, speed);
    }

    // ���ʨ禡
    void Move()
    {
        Vector3 lastPos = transform.position;
        transform.Translate(Vector3.forward);

        if (tailLength > 0)
        {
            tailList[tailLength - 1].position = lastPos;
            for (int i = tailLength - 1; i > 0; i--)
                tailList[i].position = tailList[i - 1].position;
            tailList[0].position = lastPos;
        }
    }

    // ����禡
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.up * 90);
        else if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(Vector3.up * -90);
    }

    // �I���禡
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag("Food"))
        {
            GameObject g = Instantiate(tailPrefab, tailList[tailLength - 1].position, Quaternion.identity);
            tailList[tailLength] = g.transform;
            tailLength++;
            Destroy(coll.gameObject);
        }
        else if (coll.gameObject.CompareTag("Tail"))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
