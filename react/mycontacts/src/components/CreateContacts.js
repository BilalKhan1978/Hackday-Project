import { Link,useNavigate } from "react-router-dom";
import { useState } from "react";
const CreateContacts = () =>{

  // call a method that is POST
    
    const [fullName,fullNameChange]= useState("");
    const [email,emailChange]= useState("");
    const [phone,phoneChange]= useState("");
    const [address,addressChange]= useState("");

    const navigate=useNavigate();

    const handelsubmit = (e) =>{
        e.preventDefault();
      const empdata={fullName,email,phone,address};
      // api post endpoint url
      fetch("https://localhost:7073/api/Contacts",{
        method:"POST",
        headers:{"content-type":"application/json"},
        body:JSON.stringify(empdata)
      }).then((res)=>{
        if(res.ok)
        {
          alert('Saved successfully.')
          navigate('/');
          return;
        }        
        alert('Error occured. Required fields are empty.')
      }).catch((err)=>{
        console.log(err.message)
        alert('Error occured.')
      })
    }

return(
    <div>
        
                <div>
                    <div>
                        <h2>Create Contact</h2>
                    </div>
                    <form onSubmit={handelsubmit}>
                    
                        <div>
                        <label>*Name </label>
                        </div>
                        <div>
                        <input value={fullName} onChange={e=>fullNameChange(e.target.value)}></input>
                        </div>
                        <div>
                        <label>Email</label>
                        </div>
                        <div>
                        <input value={email} onChange={e=>emailChange(e.target.value)}></input>
                        </div>
                        <div>
                        <label>*Phone </label>
                        </div>
                        <div>
                        <input value={phone} onChange={e=>phoneChange(e.target.value)}></input>
                        </div>
                        <div>
                        <label>Address</label>
                        </div>
                        <div>
                        <input value={address} onChange={e=>addressChange(e.target.value)}></input>
                        </div>  
                        <br/>                      
                        <div>
                            <button style={{background: "green"}} type="submit">Save</button>
                            <Link to="/" style={{color: "blue"}}>Back</Link>
                        </div>
                        
                    </form>
                    <div>

                    </div>
                </div>
            

    </div>
)
}

export default CreateContacts;