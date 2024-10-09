using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SelectTitle : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private int[] _layers;

    private Color _startColor;
    private GameObject _obj;
    private bool _isStay;
    void Start()
    {
        
    }

    private void Update()
    {
        var ray = _camera.ScreenPointToRay(Input.mousePosition);

       if(Physics.Raycast(ray, out RaycastHit hitInfo))
        {    

			if (_layers.Contains(hitInfo.collider.gameObject.layer)) 
            {
                if(_obj == null)
                {
					_obj = hitInfo.collider.gameObject;
					_obj.GetComponent<MeshRenderer>().material.color = Color.red;
				}
                else if (hitInfo.collider.gameObject.name != _obj.name)
                {
					_obj.GetComponent<MeshRenderer>().material.color = Color.white;
					_obj = hitInfo.collider.gameObject;
					_obj.GetComponent<MeshRenderer>().material.color = Color.red;
				}
				
            }
            else
            {
				if (_obj != null)
					_obj.GetComponent<MeshRenderer>().material.color = Color.white;
				_obj = null;
			}

		}
        else
        {
            if(_obj != null)
			    _obj.GetComponent<MeshRenderer>().material.color = Color.white;
            _obj = null;
		}
    }
}
