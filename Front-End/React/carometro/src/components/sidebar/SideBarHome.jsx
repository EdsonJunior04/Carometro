import React from "react";

import { SideBarDataHome } from "./SideBarHomeData";


import "../../assets/css/sidebar.css";

export function SideBarHome() {
  return (
    <div className="SideBar">
      <ul className="SideBarList">
        {SideBarDataHome.map((val, key) => {
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
