import React from "react";

import { SideBarData } from "./SideBarData";

import "../../assets/css/sidebar.css";

export function Sidebar() {
  return (
    <div className="SideBar">
      <ul className="SideBarList">
        {SideBarData.map((val, key) => {
          return (
            <li
              key={key}
              className="row"
              onClick={() => {
                window.location.pathname = val.link;
              }}
            >
              {" "}
              <div id="icon">{val.icon}</div> <div id="title">{val.title}</div>
            </li>
          );
        })}
      </ul>
    </div>
  );
}
