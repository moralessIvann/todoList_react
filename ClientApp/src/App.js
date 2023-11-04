import "bootstrap/dist/css/bootstrap.min.css"
import { useEffect, useState } from "react";

const App = () => {

    const [tasks, setTasks] = useState([]);
    const [taskDetails, setTaskDetails] = useState("");

    const displayTasks = async () => {
        const response = await fetch("api/todo/getlist");

        if (response.ok) {
            const data = await response.json();
            setTasks(data);
            console.log(data);
        }
        else{
            console.log("status code:" + response.status); 
        }
    }

    //method to format date
    const formatDate = (string) => {
        let options = { year: 'numeric', month: 'long', day: 'numeric' };
        let date = new Date(string).toLocaleDateString("es-PE", options);
        let hr = new Date(string).toLocaleTimeString();
        return date + " | " + hr
    }

    useEffect(() => {
        displayTasks();
    }, [])

    const saveTask = async (e) => {
        e.preventDefault()

        const response = await fetch("api/todo/Save", {
            method: "POST",
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify({ taskDetails: taskDetails })
        })

        if (response.ok) {
            setTaskDetails("");
            await displayTasks();
        }
    }

    const closeTask = async (id) => {
        /*e.preventDefault()*/

        const response = await fetch("api/todo/Close/" + id, {
            method: "DELETE",
        })

        if (response.ok) {
            await displayTasks();
        }
    }


    return (
        <div className="container bg-dark p-4 vh-100">
            <h2 className="text-white">Todo List</h2>
            <div className="row">
                <div className="col-sm-12"></div>
            </div>

            <div className="row mt-4">
                <div className="col-sm-12">
                    {/*create form*/}
                    <form onSubmit={saveTask}>
                        <div className="input-group">
                            <input type="text" className="form-control" placeholder="Enter task description"
                                value={taskDetails} onChange={(e) => setTaskDetails(e.target.value)}></input>
                            <button className="btn btn-success" type="submit">Add</button>
                        </div>
                    </form>
                    <br></br>
                    <div className="list-group">
                        {
                            tasks.map(
                                (item) => (
                                    <div key={item.idTask} className="list-group-item list-group-item-action">
                                        <h5 className="text-primary">{item.taskDetails}</h5>
                                        <div className="d-flex justify-content-between">
                                            <small className="text-muted">{formatDate(item.creationDate)}</small>
                                            <button className="btn btn-sm btn-outline-danger"
                                                onClick={() => closeTask(item.idTask)}>Close</button>
                                        </div>
                                    </div>)
                            )
                        }
                    </div>
                </div>
            </div>
        </div>
    )
}

export default App;