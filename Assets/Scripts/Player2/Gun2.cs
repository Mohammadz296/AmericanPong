public class Gun2 : Gun
{
    protected  override  void Gayer()
    {
        
        fire = gay.Map.Player2.Fire;
        fire.performed += Shooting;
        fire.Enable();

    }
 
    private void OnDisable()
    {
         fire.performed -= Shooting;
         fire.Disable();
       
    }

}
