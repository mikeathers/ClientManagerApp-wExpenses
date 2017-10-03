

var NewExpenseForms = React.createClass({

    odometerForm: function () {
        return (
            <div className="row-form-expense">
                <div className="row">
                    <div className="col-xs-6"><label >Origin</label></div>
                    <div className="col-xs-6"><label >Destination</label></div>
                </div>
                <div className="row">
                    <div className="col-xs-6"><input type="text" className="form-control" id="inputOrigin" placeholder="Enter Origin" /></div>
                    <div className="col-xs-6"><input type="text" className="form-control" id="inputDestination" placeholder="Enter Destination" /></div>
                </div>
                <br />
                <div className="row">
                    <div className="col-xs-6"><label>Odometer Start</label></div>
                    <div className="col-xs-6"><label>Odometer End</label></div>
                </div>
                <div className="row">
                    <div className="col-xs-6"><input type="text" className="form-control" id="inputOrigin" placeholder="Enter Start" /></div>
                    <div className="col-xs-6"><input type="text" className="form-control" id="inputDestination" placeholder="Enter End" /></div>
                </div>
                <br />
                <div className="row">
                    <div className="col-xs-6"><label>Total Miles:</label><label id="totalMiles">100</label></div>
                    <div className="col-xs-6"><label>Total Cost:</label><label id="totalCost">£25.00</label></div>
                </div>
                <br />                
            </div>
        )
    },
    googleMapsForm: function () {
        return (
            <div className="row-form-expense">
                <div className="row">
                    <div className="col-xs-6"><label htmlFor="inputOriginMaps">Origin</label></div>
                    <div className="col-xs-6"><label htmlFor="inputDestinationMaps">Destination</label></div>
                </div>
                <div className="row">
                    <div className="col-xs-6"><input type="text" className="form-control" id="inputOriginMaps" placeholder="Enter Origin" /></div>
                    <div className="col-xs-6"><input type="text" className="form-control" id="inputDestinationMaps" placeholder="Enter Destination" /></div>
                </div>
                <br />
                <div className="row">
                    <div className="col-xs-6"><label htmlFor="totalMiles">Total Miles:</label><label id="totalMilesMaps">100</label></div>
                    <div className="col-xs-6"><label htmlFor="totalCost">Total Cost:</label><label id="totalCostMaps">£25.00</label></div>
                </div>
                <br />
            </div>
        );
    },

    parkingForm: function () {
        return (
            <div className="row-form-expense">
                <div className="row">
                    <div className="col-xs-6"><label>Total Cost (£):</label></div>
                </div>
                <div className="row">
                    <div className="col-xs-6"><input type="text" className="form-control" id="inputParkingTotalCost" placeholder="Enter Total Cost" /></div>
                </div>
                <br />
            </div>
        );
    },
    otherExpenseForm: function () {
        return (
            <div className="row-form-expense">
                <div className="row">
                    <div className="col-xs-6"><label>Reason For Expense:</label></div>
                </div>
                <div className="row">
                    <div className="col-xs-6"><textarea rows="5" cols="10" className="form-control" id="inputParkingTotalCost" placeholder="Enter Reason" /></div>
                </div>
                <br />

                <div className="row"><label>Total Cost (£):</label></div>
                <div className=""><input type="text" className="form-control" id="inputParkingTotalCost" placeholder="Enter Total Cost" /></div>
                <br />
            </div>
        );

    },


    render: function () {

        let form = "";

        switch (this.props.format) {
            case "odometer":
                form = this.odometerForm();
                break;
            case "googleMaps":
                form = this.googleMapsForm();
                break;
            case "parking":
                form = this.parkingForm();
                break;
            case "other":
                form = this.otherExpenseForm();
                break;

        }
        return ( <div> {form} </div> )
    }
});

var NewExpenseButtons = React.createClass({

    getInitialState: function () {
        return {
            typeSelected: "mileage",
            format: "odometer"
        }
    },

    componentSelected: function (e, type) {
        e.preventDefault();

        switch (type) {
            case "odometer":
                this.setState({
                    typeSelected: this.props.typeSelected,
                    format: "odometer"
                });
                break;
            case "googleMaps":
                this.setState({
                    typeSelected: this.props.typeSelected,
                    format: "googleMaps"
                });
                break;
            case "parking":
                this.setState({
                    typeSelected: this.props.typeSelected,
                    format: "parking"
                });
                break;
            case "other":
                this.setState({
                    typeSelected: this.props.typeSelected,
                    format: "other"
                });
                break;
        }
    },

    renderButtons: function () {
        if (this.props.typeSelected === "mileage") {
            return (

                <div className="row btn-row">
                    <button className="btn btn-primary" id="odometerBtn" onClick={(event) => this.componentSelected(event, "odometer")}>Odometer</button>
                    <button className="btn btn-primary" id="googleMapsBtn" onClick={(event) => this.componentSelected(event, "googleMaps")}>Google Maps</button>
                </div>
            );
        }
        else {
            return (

                <div className="row btn-row">
                    <button className="btn btn-primary" id="parkingBtn" onClick={(event) => this.componentSelected(event, "parking")}>Parking</button>
                    <button className="btn btn-primary" id="otherExpBtn" onClick={(event) => this.componentSelected(event, "other")}>Other</button>
                </div>

            );
        }
    },


    render: function () {
        return (
            <div>
                {this.renderButtons()}
                <br />
                <NewExpenseForms format={this.state.format} />
                <div className="row">
                    <div className="col-xs-6"><input type="submit" value="Submit" className="btn btn-success" /></div>
                </div>
            </div>
        );
    }


});

var NewExpense = React.createClass({


    getInitialState: function () {
        return {
            typeSelected: "mileage",
            format: "odometer",
        }
    },


    mileageSelected: function (e) {
        e.preventDefault();
        this.setState({
            typeSelected: "mileage",
            format: "odometer"
        });
    },

    workExpenseSelected: function (e) {
        e.preventDefault();
        this.setState({
            typeSelected: "workExpense",
            format: "parking"
        });
    },

    handleSubmit: function (e) {
        e.preventDefault();

    },

    render: function () {
        return (

            <form className="form-horizontal" onSubmit={this.handleSubmit}>
                <fieldset>

                    <div className="form-group">
                        <label>Date</label>
                        <input type="date" className="form-control" id="inputDate" />
                    </div>


                    <div className="form-group">
                        <label>Type</label><br />
                        <div className="btn-row-container">
                            <div className="row btn-row">
                                <button className="btn btn-primary" id="mileageBtn" onClick={this.mileageSelected}>Mileage</button>
                                <button className="btn btn-primary" id="workExpenseBtn" onClick={this.workExpenseSelected}>Work Expense</button>
                            </div>
                            

                            <NewExpenseButtons typeSelected={this.state.typeSelected} format={this.state.format} />
                            

                        </div>

                    </div>
                </fieldset>
            </form>





    
        );
    }
});


ReactDOM.render(
    <NewExpense />,
    document.getElementById('content')
);