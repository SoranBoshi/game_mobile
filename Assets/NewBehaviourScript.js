#pragma strict
 var speed : float = 5;
 var jumpForce : float = 20;
  
 function Update () 
 {
     if (Input.GetKey(KeyCode.S))
     {
     this.transform.position.x += this.speed*Time.deltaTime;
     }
  
         if (Input.GetKey(KeyCode.A))
         {
         this.transform.position.z += this.speed*Time.deltaTime;
         }
  
             if (Input.GetKey(KeyCode.W))
             {
             this.transform.position.x -= this.speed*Time.deltaTime;
             }
  
                 if (Input.GetKey(KeyCode.D))
                 {
                 this.transform.position.z -= this.speed*Time.deltaTime;
                 }
  
                     if ( Input.GetKeyDown("space") ) 
                     {
                     Jump();
                     }
  
 }
  
                         function Jump()
                         {
                         yield WaitForSeconds(2);
                         rigidbody.AddForce (Vector3.up *jumpForce*Time.deltaTime);
                         }