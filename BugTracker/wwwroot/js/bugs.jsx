var BugBox = React.createClass({
  render: function() {
    return (
      <div className="bugBox">
        Hello, world! I am a bug.
      </div>
    );
  }
});
ReactDOM.render(
  React.createElement(BugBox, null),
  document.getElementById('content')
);