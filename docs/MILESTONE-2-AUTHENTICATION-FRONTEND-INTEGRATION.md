# WimabEvent — Milestone 2 Progress Record

**Milestone:** 2 — Authentication & Frontend Integration  
**Status:** IN PROGRESS  
**Progress Recorded:** 31 August – 1 September 2026  
**Project:** WimabEvent  
**Developer:** Wisani Mabunda

---

## 1. Milestone Purpose

Milestone 2 focuses on connecting the WimabEvent frontend to the application's real authentication system and progressively replacing presentation/mock data with real backend data.

The milestone builds on the existing ASP.NET Core Identity authentication system, event management functionality, guest management, invitations and gift registry/catalogue functionality.

---

## 2. Completed Progress

### 2.1 Authentication

The login endpoint was updated to use ASP.NET Core Identity's PasswordSignInAsync functionality instead of only checking the password.

The authentication flow now:

- Validates the supplied email and password.
- Establishes an authenticated Identity session.
- Creates a persistent authentication cookie.
- Enables lockout-on-failure.
- Returns an appropriate response when an account is temporarily locked.
- Returns Unauthorized when credentials are invalid.

### 2.2 Registration Testing

A real test account was successfully registered through the authentication API.

Test account used during development:

- Email: wimabtest@example.com
- Password: WimabTest@123
- Name: Wimab Test Host

The registration endpoint returned HTTP 200 and successfully created the Identity user.

### 2.3 Login Testing

The newly created test account was successfully authenticated through:

`POST /api/auth/login`

The endpoint returned HTTP 200 with a successful login response.

The authentication response also issued an ASP.NET Core Identity authentication cookie, confirming that the server-side Identity session was being established.

Invalid credentials were previously confirmed to return HTTP 401 Unauthorized.

### 2.4 Event Creation Testing

After authentication was verified, event creation was tested through the frontend.

A test event was successfully created:

- Event: Wisani Test Celebration
- Description: Fun and vibes
- Date: 4 September 2026
- Location: Johannesburg, Sandton

The event was successfully persisted and appeared on the Events page.

### 2.5 Landing Page Improvements

The landing page was further refined to present WimabEvent as a professional product.

Changes included:

- Added a professional developer/profile section.
- Added the developer image.
- Improved the public contact section.
- Added a clickable developer email address.
- Removed the personal phone number from the public contact section.
- Removed the location item from the contact section.
- Added a Wimab Event Hub description.
- Added a Get Started contact/action item.
- Added styling for the clickable email address.
- Continued improving the landing page visual presentation.

### 2.6 Build Verification

The application successfully builds with:

`dotnet build`

The build currently succeeds with the existing SQLitePCLRaw.lib.e_sqlite3 vulnerability warning.

The warning does not currently prevent the application from building or running.

---

## 3. Important Discovery

During frontend testing, a difference was identified between the dashboard and the Events page.

The Events page is connected to the backend and displays real events retrieved from the database.

The dashboard, however, still contains presentation/mock data such as:

- Birthday Celebration
- Graduation Celebration
- Family Gathering
- Sample invitation activity
- Sample guest counts
- Sample wishlist counts

The dashboard statistics also do not yet represent the currently authenticated user's actual database records.

For example, a newly created event can appear on the Events page while the dashboard may still display zero events and unrelated sample events.

This is now identified as a required part of Milestone 2.

---

## 4. Authentication Architecture Observation

The application now has a server-side ASP.NET Core Identity authentication session.

However, some existing frontend pages still use localStorage values such as `wimab_userid` to determine whether a user is logged in.

This means the frontend authentication checks are not yet fully aligned with the server-side Identity session.

The final authentication architecture should use ASP.NET Core Identity as the authoritative authentication mechanism rather than relying on a client-controlled localStorage value.

---

## 5. Current Milestone Status

Milestone 2 is currently **IN PROGRESS**.

Authentication has been successfully tested, but frontend authentication integration and dashboard data integration are not yet complete.

The application currently has a working foundation for:

- User registration
- User login
- Identity authentication sessions
- Event creation
- Event listing
- Gift registry/catalogue functionality

Further integration is required before this milestone can be marked complete.

---

## 6. Next Development Tasks

### Dashboard

- Connect dashboard event statistics to the database.
- Display the authenticated user's actual events.
- Remove hardcoded sample events.
- Connect guest counts to real database records.
- Connect invitation counts to real database records.
- Connect wishlist counts to real database records.
- Display real recent invitations.
- Remove mock invitation statuses.

### Authentication

- Replace localStorage-based authentication checks with server-side authentication checks.
- Ensure authenticated pages cannot be accessed without a valid Identity session.
- Verify logout invalidates the authenticated session.
- Verify protected API endpoints use appropriate authorization.
- Continue testing invalid and locked-out login scenarios.

### Event Ownership

- Ensure users can only retrieve and manage their own events.
- Ensure event creation associates the event with the authenticated user.
- Prevent users from accessing another user's private event data.

### Final Testing

- Registration test
- Duplicate registration test
- Valid login test
- Invalid login test
- Logout test
- Protected-page test
- Event creation test
- Event listing test
- User-specific event test
- Dashboard statistics test
- Guest/invitation/wishlist integration test

---

## 7. Development Notes

The main objective of this milestone is not to redesign the application from scratch. The existing dashboard and frontend visual design will be retained where appropriate while replacing mock presentation data with real backend-driven data.

The authentication work establishes the foundation for user-specific data and protected application functionality.

---

## 8. Milestone Completion Criteria

Milestone 2 will be considered complete when:

- [ ] Frontend login uses the real ASP.NET Core Identity authentication flow.
- [ ] Registration and login are fully integrated into the frontend.
- [ ] Authenticated pages rely on the server-side authentication session.
- [ ] Logout correctly ends the authenticated session.
- [ ] Dashboard statistics come from the database.
- [ ] Dashboard events belong to the authenticated user.
- [ ] Mock dashboard data has been removed.
- [ ] Guests, invitations and wishlist information are connected to real data.
- [ ] User-specific event access has been verified.
- [ ] The complete authentication and dashboard flow has been tested.
- [ ] Changes have been committed and pushed to GitHub.

---

## 9. Development Journal

### 31 August 2026

Authentication integration was continued using ASP.NET Core Identity.

The login endpoint was changed from CheckPasswordSignInAsync to PasswordSignInAsync so that successful login establishes an authenticated Identity session.

A real test account was registered and successfully authenticated.

The authentication cookie was observed during testing, confirming that the Identity session was being established.

Event creation was then tested through the authenticated application. A test event named "Wisani Test Celebration" was successfully created and displayed on the Events page.

The landing page was also refined with a professional developer section, developer image and improved contact information.

### 1 September 2026

Frontend testing revealed that the dashboard still contains hardcoded presentation data while the Events page is displaying real database data.

This distinction was documented as the next major development task.

The next development session will focus on converting the dashboard into a fully database-driven, user-specific dashboard.

---

## 10. Current Checkpoint

**Milestone 1:** COMPLETE  
Gift Registry & Catalogue functionality completed, tested, committed and pushed.

**Milestone 2:** IN PROGRESS  
Authentication foundation and frontend integration underway.

**Next checkpoint:** Real user-specific dashboard and authentication integration.
