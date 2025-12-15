/**
 * @fileoverview This is the service worker for notifications.
 * @author Tayra Sakurai <b4151069@edu.kit.ac.jp>
 * @copyright Copyright (C) 2025 Tayra Sakurai
 * @license Copyright (C) 2025 Tayra Sakurai
 * 
 * This is a part of FinanceNote.
 * 
 * FinanceNote is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or any later version.
 * 
 * FinanceNote is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License along with FinanceNote. If not, see <https://www.gnu.org/licenses/>.
 */

/**
 * This is the notification reciever.
 * @param {PushEvent} event The push event.
 */
function sendNotification(event) {
    /**
     * Checks if the permission is granted.
     */
    if (!(self.Notification && self.Notification.permission == 'granted'))
        return;

    /**
     * The notification data.
     * @type {PushMessageData|Object}
     */
    const data = event.data?.json() ?? {};
    /**
     * The message body.
     * @type {string}
     */
    const body =
        data.body || 'Something has happened. Please check out the notification.';
    /**
     * The message title.
     * @type {string}
     */
    const title = data.title || 'Something';
    /**
     * The icon path.
     * @type {string}
     */
    const icon = '~/favicon.ico';
    /**
     * The tag.
     * @type {string}
     */
    const tag =
        data.tag || 'notification-all';
    /**
     * The notification instance.
     * @lends {self.Notification}
     */
    const notification = new self.Notification(
        title,
        {
            body,
            icon,
            tag,
        }
    );

    notification.addEventListener(
        'click',
        () => {
            clients.openWindow(
                '/Home/Index'
            );
        }
    );
}

self.addEventListener(
    'push',
    sendNotification
);