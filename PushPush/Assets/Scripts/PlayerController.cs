using UnityEngine;
using System.Collections;
using System.Linq;

public enum Direction 
{
	Left,
	Right,
	Up,
	Down
};

public class PlayerController : MonoBehaviour 
{
	[HideInInspector]
	
    private Animator anim;
	private bool isMoving = false;
	private Vector3 startPosition;
	private Vector3 endPosition;
	private float t;
	private float factor;
    private int d=1;
    private bool beginning = true;
    private int dPrev = 1;
    private int angle = 0;
    private bool push = false;
    private bool CheckAu = true;

	public string tagCrate = "Box";
	public string tagWall = "Wall";
	public string tagSwitch = "Switch";
    public GameObject korobka;
    public GameObject camera;
    public AudioClip tr;
    public float moveSpeed = 3f;	
	public float gridSize;
    public Vector2 input;	
    void Awake()
    {
        anim = GetComponent<Animator>();
    }
	bool CanMove(Direction dir)
	{
		Vector3 direction = Vector3.zero;

		switch(dir)
		{
			case Direction.Left:
				direction = Vector3.left;
				break;

			case Direction.Right:
				direction = Vector3.right;
				break;

			case Direction.Down:
				direction = Vector3.down;
				break;

			case Direction.Up:
				direction = Vector3.up;
				break;
		}        
		RaycastHit hit;        
        if (!Physics.Raycast(transform.position, direction, out hit, gridSize))
        {
            return true;
        }		
		if(hit.collider.tag == tagWall)
		{
            return false;
		}		
		if (hit.collider.tag == tagCrate)
		{
            RaycastHit[] hits = Physics.RaycastAll(transform.position, direction, 2*gridSize).OrderBy(h=>h.distance).ToArray();
			if(hits.Length == 1)
			{
                push = true;
				return true;
			}			
			else if(hits.Length > 1)
			{
				int crateCount = 0;
				bool bSwitch = false;
				foreach(RaycastHit h in hits)
				{					
					if(h.collider.tag == tagCrate)
						crateCount++;					
					if(crateCount >= 2)
					{
						return false;
					}					
					if(h.collider.tag == tagSwitch)
						bSwitch = true;					
					if(h.collider.tag == tagWall)
						return false;
				}
                if (bSwitch)
                {                    
                    push = true;
                    return true;
                }
			}
		}
		return true;
	}
	public void Update() 
	{
		if (!isMoving && !beginning) 
		{
			sbyte xIn = 0;
			sbyte yIn = 0;

			Vector3 vRotZ = new Vector3(0,0,angle);
			transform.Rotate(vRotZ);

			if(d==2) // move Left
			{
                if (CanMove(Direction.Left))
                {
                    GM.instance.progress +=(GM.instance.moves + 1).ToString() + "← ";
                    xIn = -1;
                }
			}
			else if(d==4) // move Right
			{
				if(CanMove(Direction.Right))
				{
					xIn = 1;
					GM.instance.progress += (GM.instance.moves + 1).ToString() + "→ ";
				}
			}
			else if(d==3) // move Down
			{
				if(CanMove(Direction.Down))
				{
					yIn = -1;
					GM.instance.progress += (GM.instance.moves + 1).ToString() + "↓ ";
				}
			}
			else if(d==1) // move Up
			{
				if(CanMove(Direction.Up))
				{
					yIn = 1;
					GM.instance.progress += (GM.instance.moves + 1).ToString() + "↑ ";
				}
			}

			input = new Vector2((float)xIn, (float)yIn);
			
			if (input != Vector2.zero) 
			{

                if (push)
                {
                    if (CheckAu)
                    {
                        AudioSource.PlayClipAtPoint(tr, camera.transform.position);
                    }
                    anim.SetTrigger("Push");                    
                    push = false;
                }
                else
                {
                    anim.SetTrigger("Move");
                }
                GM.instance.moves++;
                GM.instance.UpdateMoves();
				StartCoroutine(move(transform));               
            }
			d = 0;
		}
	}
	
	public IEnumerator move(Transform transform) 
	{
		isMoving = true;
		startPosition = transform.position;
		t = 0;		
		endPosition = new Vector3(startPosition.x + System.Math.Sign(input.x) * gridSize,
			                      startPosition.y + System.Math.Sign(input.y) * gridSize, 
		                          startPosition.z);		
		factor = 1f;		
		while (t < 1f) 
		{
			t += Time.deltaTime * (moveSpeed/gridSize) * factor;
			transform.position = Vector3.Lerp(startPosition, endPosition, t);
			yield return null;
		}
		isMoving = false;
        d = 0;
		yield return 0;
	}
    public void Up()
    {
        if(GM.instance.game)
        {
	        beginning = false;
	        d = 1;
	        transform.Rotate(new Vector3(0,0,(d-dPrev)*90));
	        dPrev = d;
    	}
    }
    public void Down()
    {
        if(GM.instance.game)
        {
	        beginning = false;
	        d = 3;
	        transform.Rotate(new Vector3(0,0,(d-dPrev)*90));
	        dPrev = d;
    	}
    }
    public void Left()
    {
        if(GM.instance.game)
        {
	        beginning = false;
	        d = 2;
	        transform.Rotate(new Vector3(0,0,(d-dPrev)*90));
	        dPrev = d;
    	}
    }
    public void Right()
    {
        if(GM.instance.game)
        {
	        beginning = false;
	        d = 4;
	        transform.Rotate(new Vector3(0,0,(d-dPrev)*90));
	        dPrev = d;
    	}
    }
    public void CheckAudio()
    {
        CheckAu = !CheckAu;
    }
}
