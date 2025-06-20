export const API_ENDPOINTS = {
  // 1st 4 is done
  AUTH: {
    LOGIN: '/Login/LoginUser',
    REGISTER: '/Login/Register',
    GET_LOGIN_USER_BY_ID: '/Login/LoginUserDetailById',
    UPDATE_USER_PROFILE: '/Login/LoginUserProfileUpdate',
    FORGOT_PASSWORD: '/Login/ForgotPassword',
    RESET_PASSWORD: '/Login/ResetPassword',
    CHANGE_PASSWORD: '/Login/ChangePassword',
    GET_USER_BY_ID: '/Login/GetUserById',
    UPDATE_USER: '/Login/UpdateUser',
    GET_USER_PROFILE: '/Login/GetUserProfileDetailById',
  },
  // 1st 7 is done
  MISSION: {
    LIST: '/Mission/MissionList',
    ADD: '/Mission/AddMission',
    THEME_LIST: '/Mission/GetMissionThemeList',
    SKILL_LIST: '/Mission/GetMissionSkillList',
    APPLICATION_LIST: '/Mission/MissionApplicationList',
    APPLICATION_APPROVE: '/Mission/MissionApplicationApprove',
    APPLICATION_DELETE: '/Mission/MissionApplicationDelete',
    DETAIL: '/Mission/MissionDetailById',
    UPDATE: '/Mission/UpdateMission',
    DELETE: '/Mission/DeleteMission',
  },
  // 1st 2 is done
  CLIENT_MISSION: {
    LIST: '/ClientMission/ClientSideMissionList',
    APPLY: '/ClientMission/ApplyMission',
    CLIENT_LIST: '/ClientMission/MissionClientList',
    DETAIL: '/ClientMission/MissionDetailByMissionId',
    ADD_COMMENT: '/ClientMission/AddMissionComment',
    COMMENT_LIST: '/ClientMission/MissionCommentListByMissionId',
    ADD_FAVORITE: '/ClientMission/AddMissionFavourite',
    REMOVE_FAVORITE: '/ClientMission/RemoveMissionFavourite',
    RATING: '/ClientMission/MissionRating',
    RECENT_VOLUNTEERS: '/ClientMission/RecentVolunteerList',
    GET_USER_LIST: '/ClientMission/GetUserList',
    SEND_INVITE: '/ClientMission/SendInviteMissionMail',
    MISSION_TITLE: '/Story/GetMissionTitle',
  },
  // ContactUs is pending in Logic
  COMMON: {
    COUNTRY_LIST: '/Common/CountryList',
    CITY_LIST: '/Common/CityList',
    UPLOAD_IMAGE: '/Common/UploadImage',
    CONTACT_US: '/Common/ContactUs',
    ADD_USER_SKILL: '/Common/AddUserSkill',
    GET_USER_SKILL: '/Common/GetUserSkill',
    MISSION_TITLE_LIST: '/Common/MissionTitleList',
    MISSION_COUNTRY_LIST: '/Common/MissionCountryList',
    MISSION_CITY_LIST: '/Common/MissionCityList',
    MISSION_THEME_LIST: '/Common/MissionThemeList',
    MISSION_SKILL_LIST: '/Common/MissionSkillList',
  },
  // all are left
  TIMESHEET: {
    GET_HOURS_LIST: '/VolunteeringTimesheet/GetVolunteeringHoursList',
    GET_HOURS_BY_ID: '/VolunteeringTimesheet/GetVolunteeringHoursListById',
    ADD_HOURS: '/VolunteeringTimesheet/AddVolunteeringHours',
    UPDATE_HOURS: '/VolunteeringTimesheet/UpdateVolunteeringHours',
    DELETE_HOURS: '/VolunteeringTimesheet/DeleteVolunteeringHours',
    GET_GOALS_LIST: '/VolunteeringTimesheet/GetVolunteeringGoalsList',
    GET_GOALS_BY_ID: '/VolunteeringTimesheet/GetVolunteeringGoalsListById',
    ADD_GOALS: '/VolunteeringTimesheet/AddVolunteeringGoals',
    UPDATE_GOALS: '/VolunteeringTimesheet/UpdateVolunteeringGoals',
    DELETE_GOALS: '/VolunteeringTimesheet/DeleteVolunteeringGoals',
    VOLUNTEERING_MISSION_LIST: '/VolunteeringTimesheet/VolunteeringMissionList',
  },
  //Done
  AdminUser: {
    USER_LIST: '/AdminUser/UserDetailList',
    DELETE_USER: '/AdminUser/DeleteUser',
  },
  //Done
  MISSION_THEME: {
    LIST: '/MissionTheme/GetMissionThemeList',
    GET_BY_ID: '/MissionTheme/GetMissionThemeById',
    ADD: '/MissionTheme/AddMissionTheme',
    UPDATE: '/MissionTheme/UpdateMissionTheme',
    DELETE: '/MissionTheme/DeleteMissionTheme',
  },
  //Done
  MISSION_SKILL: {
    LIST: '/MissionSkill/GetMissionSkillList',
    GET_BY_ID: '/MissionSkill/GetMissionSkillById',
    ADD: '/MissionSkill/AddMissionSkill',
    UPDATE: '/MissionSkill/UpdateMissionSkill',
    DELETE: '/MissionSkill/DeleteMissionSkill',
  },
};
