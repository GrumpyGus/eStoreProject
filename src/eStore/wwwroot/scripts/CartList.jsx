//
// ReactBootstrap Component variables
//
var ListGroup = ReactBootstrap.ListGroup;
var ListGroupItem = ReactBootstrap.ListGroupItem;
var Modal = ReactBootstrap.Modal;

var listStyle = {
    paddingBottom: "35px"
}

var listHeadStyle = {
    minHeight: "30px",
    marginBottom: "0px",
    paddingTop: "3px",
    backgroundColor: "#222",
    color: "#9D9D9D"
}

var headStyle = {
    backgroundColor: "#222",
    color: "#9D9D9D",
    top: "25px",
    position: "relative"
}

//
// ModalDetails Component
//
var ModalDetails = React.createClass({
    render: function () {
        return (
           <ListGroupItem style={listStyle}>
                <div className="col sm-5 col-xs-5 bold">{this.props.details.ProductName}</div>
                <div className="col-sm-2 col-xs-2 bold">${this.props.details.SoldPrice.toFixed(2)}</div>
                <div className="col-sm-1 col-xs-1 bold">{this.props.details.QtySold}</div>
                <div className="col-sm-1 col-xs-1 bold">{this.props.details.QtyOrdered}</div>
                <div className="col-sm-1 col-xs-1 bold">{this.props.details.QtyBackOrdered}</div>
                <div className="col-sm-2 col-xs-2 bold">${(this.props.details.QtyOrdered * this.props.details.SoldPrice).toFixed(2)}</div>
            </ListGroupItem>
        )
    }
});

//
// Cart Component
//
var Cart = React.createClass({
    getInitialState() {
        return { showModal: false, cartdetails: [] };
    },
    close() {
        this.setState({ showModal: false });
    },
    open() {
        this.setState({ showModal: true });
        var cart = this.props.cart;
        var url = this.props.source + "/" + cart.Id;
        httpGet(url, function (data) {
            this.setState({ cartdetails: data });
        }.bind(this));
    },
    CalculateTotal: function () {
        var tot = 0.0;
        var total = this.state.cartdetails.map(details =>
            tot = tot + (details.SoldPrice * details.QtyOrdered)
        )
        return tot;
    },
    render: function () {
        var detailsForModal = this.state.cartdetails.map(details =>
            <ModalDetails details={details} key={details.ProductId} />
        );
        return (
            <div>
                <ListGroupItem onClick={this.open}>
                    <span className="col-xs-3 text-left">{this.props.cart.Id}</span>
                    <span className="col-xs-9 orderline">{formatDate(this.props.cart.DateCreated)}</span>
                </ListGroupItem>
                <Modal show={this.state.showModal} onHide={this.close}>
                    <Modal.Header closeButton>
                        <Modal.Title>
                            <div>
                                <span className="col-xs-12">&nbsp;</span>
                                <span className="col-xs-3 text-center">Order:{this.props.cart.Id}</span>
                                <span className="col-xs-9 text-right xsmallFont">Date:{formatDate(this.props.cart.DateCreated)}</span>
                            </div>
                        </Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                        <ListGroup>
                            <div style={listHeadStyle} className="text-center navbar navbar-default top25">
                                <div className="col sm-5 col-xs-5 top10 bold">Product</div>
                                <div className="col-sm-2 col-xs-2 top10 bold">MSRP</div>
                                <div className="col-sm-1 col-xs-1 top10 bold">QtyS</div>
                                <div className="col-sm-1 col-xs-1 top10 bold">QtyO</div>
                                <div className="col-sm-1 col-xs-1 top10 bold">QtyB</div>
                                <div className="col-sm-2 col-xs-2 top10 bold">Extended</div>
                            </div>
                            {detailsForModal}
                        </ListGroup>
                    </Modal.Body>
                    <Modal.Footer>
                        <div className="text-right">
                            <span className="col-xs-10">SubTotal:</span>
                            <span className="col-xs-2">${(this.CalculateTotal()).toFixed(2)}</span>
                            <span className="col-xs-10">Tax:</span>
                            <span className="col-xs-2">${(this.CalculateTotal() * 0.13).toFixed(2)}</span>
                            <span className="col-xs-10">Order Total:</span>
                            <span className="col-xs-2">${(this.CalculateTotal() * 1.13).toFixed(2)}</span>
                        </div>
                    </Modal.Footer>
                </Modal>
            </div>
        )
    }
});

//
// CartList Component
//
var Cartlist = React.createClass({
    getInitialState: function () {
        return ({ carts: [] });
    },
    componentDidMount: function () {
        httpGet(this.props.source, function (data) {
            this.setState({ carts: data });
        }.bind(this));
    },
    render: function () {
        var carts = this.state.carts.map(cart => <Cart cart={cart} key={cart.Id} source="/GetOrderDetails" />);
        return (
            <div className="top25">
                <div className="col-sm-4 col-xs-1">&nbsp;</div>
                <div className="col-sm-4 col-xs-12">
                    <div className="panel-title text-center">
                        <h3>Orders You've Saved</h3>
                        <img className="smaller-img" src="/img/Cart.png" />
                    </div>
                    <div className="panel-body">
                        <div>
                            <div className="text-center navbar navbar-default" style={headStyle}>
                                <div className="col sm-4 col-xs-2" style={{ top: "10px", position: "relative" } }>#</div>
                                <div className="col-sm-8 col-xs-10" style={{ top: "10px", position: "relative" } }>Date</div>
                            </div> 
                            <ListGroup>{carts}</ListGroup>
                        </div>
                    </div>
                </div>
            </div>
        )
    }
});

ReactDOM.render(
    <Cartlist source="/GetCarts" />,
    document.getElementById("CartList") // html tag
)